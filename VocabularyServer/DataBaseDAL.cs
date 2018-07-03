﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using DAL.Models;

namespace DAL
{
    public class DataBaseDAL : IDataBaseDAL
    {
        public readonly string CardsIsNotLearned = "000000";
        public readonly string CardsIsLearned = "111111";
        public readonly VocabularyModel _ctx;
        public DataBaseDAL(DbContext ctx)
        {
            _ctx = (VocabularyModel)ctx;
        }
        public bool IsEmailAddressExists(string email)
        {
            return _ctx.Credentials.Any(x => x.Email == email);
        }
        public bool IsDictionaryNameExists(string dictionaryName, int userId)
        {
            return _ctx.Dictionaries.Any(x => x.Credential.Id == userId
                                           && x.Name == dictionaryName);
        }

        public int? GetUserIdByCredential(Credential credential)
        {
            var cred = _ctx.Credentials.Where(x => x.Email == credential.Email && x.Password == credential.Password)
                                       .SingleOrDefault();
            if (cred != null)
            {
                return cred.Id;
            }
            return null;
        }
        public CredentialExtn GetCredentialById(int userId)
        {
            return _ctx.Credentials.Where(x => x.Id == userId)
                                   .SingleOrDefault();
        }
        public bool AddCredential(CredentialExtn credential)
        {
            int countBefore = _ctx.Credentials.Count();
            _ctx.Credentials.Add(credential);
            _ctx.SaveChanges();
            int countAfter = _ctx.Credentials.Count();
            return countAfter > countBefore;
        }
        public bool AddWord(Word word)
        {
            int countBefore = _ctx.Words.Count();
            _ctx.Words.Add(word);
            _ctx.SaveChanges();
            int countAfter = _ctx.Words.Count();
            return countAfter > countBefore;
        }
        public bool DeleteWord(int wordId)
        {
            int countBefore = _ctx.Words.Count();
            var wordToDelete = _ctx.Words.Where(x => x.Id == wordId).SingleOrDefault();
            _ctx.Words.Remove(wordToDelete);
            _ctx.SaveChanges();
            int countAfter = _ctx.Words.Count();
            return countBefore > countAfter;
        }
        public void UpdateWord(Word newWord)
        {
            var word = _ctx.Words.Where(x => x.Id == newWord.Id).SingleOrDefault();
            if(word != null)
            {
                word.WordEng = newWord.WordEng;
                word.Transcription = newWord.Transcription;
                word.Translation = newWord.Translation;
                word.IsWordLearned = newWord.IsWordLearned;
                if(newWord.IsWordLearned == false)
                {
                    word.IsCardPassed = CardsIsNotLearned;
                    word.TimeWordBecameLearned = default(DateTime);
                    word.IsWordRepeat = false;
                }
                else
                {
                    word.IsCardPassed = CardsIsLearned;
                    word.TimeWordBecameLearned = DateTime.Now;
                    word.IsWordRepeat = true;
                }
            }
            _ctx.SaveChanges();
        }
        public List<Word> GetWords(int dictionaryId)
        {
            return _ctx.Words.Where(x => x.Dictionary.Id == dictionaryId)
                             .ToList();
        }
        public List<Word> GetNotLearnedWords(int userId)
        {
            return _ctx.Words.Where(x => x.Dictionary.Credential.Id == userId 
                                        && x.IsWordInProcessStuding == true)
                             .ToList();
        }
        public List<Word> GetNotLearnedWords(int dictionaryId, int quantityWords)
        {
            var isLearningProcessActive = _ctx.Words.Where(x => x.Dictionary.Id == dictionaryId)
                                                    .Any(x => x.IsWordInProcessStuding == true);
            if (!isLearningProcessActive)
            {
                _ctx.Words.Where(x => x.Dictionary.Id == dictionaryId
                                    && x.IsWordLearned == false)
                        .Take(quantityWords)
                        .ToList()
                        .ForEach(x => x.IsWordInProcessStuding = true);
                _ctx.SaveChanges();
            }
            return _ctx.Words.Where(x => x.Dictionary.Id == dictionaryId
                                        && x.IsWordInProcessStuding == true)
                             .ToList();
        }
        public List<Word> GetWordsToRepeat(int userId) // chnage minutes to days
        {
            return _ctx.Words.Where(x => x.Dictionary.Credential.Id == userId
                                        && (DateTime.Now - x.TimeWordBecameLearned).Minutes > 1
                                        && (DateTime.Now - x.TimeWordBecameLearned).Minutes < 2)
                             .ToList();
        }
        public int GetQuantityUnlearnedWordsInDictionary(int dictionaryId)
        {
            return _ctx.Words.Count(x => x.Dictionary.Id == dictionaryId && x.IsWordLearned == false);
        }
        public int? IsLearningProcessActive(int userId)
        {
            var res = _ctx.Words.Any(x => x.Dictionary.Credential.Id == userId
                                        && x.IsWordInProcessStuding == true);
            if (res)
            {
                return _ctx.Words.FirstOrDefault(x => x.Dictionary.Credential.Id == userId
                                                    && x.IsWordInProcessStuding == true).Dictionary.Id;
            }
            return null;
        }
        public void ChangeOutstandingWords(int userId)
        {
            _ctx.Words.Where(x => x.Dictionary.Credential.Id == userId
                                && (DateTime.Now - x.TimeWordBecameLearned).Days > 2)
                      .ToList()
                      .ForEach(x =>
                      {
                          x.IsCardPassed = CardsIsNotLearned;
                          x.IsWordLearned = false;
                          x.IsWordInProcessStuding = false;
                          x.IsWordRepeat = false;
                          x.TimeWordBecameLearned = default(DateTime);
                      });
            _ctx.SaveChanges();
        }
        public void ChangeStatusCards(Dictionary<int, string> newCardsStatuses, int dictionaryId)
        {
            _ctx.Words.Where(x => x.Dictionary.Id == dictionaryId
                                            && newCardsStatuses.Keys.Contains(x.Id))
                                  .ToList()
                                  .ForEach(x =>
                                  {
                                      x.IsCardPassed = newCardsStatuses[x.Id];
                                      if (newCardsStatuses[x.Id] == CardsIsLearned)
                                      {
                                          x.IsWordLearned = true;
                                      }
                                  });
            _ctx.SaveChanges();
        }
        public void SetToWordsStatusAsLearned(int[] wordsId, int dictionaryId)
        {
            _ctx.Words.Where(x => x.Dictionary.Id == dictionaryId
                           && wordsId.Contains(x.Id))
                 .ToList()
                 .ForEach(x => {
                     x.IsWordLearned = true;
                     x.IsCardPassed = CardsIsLearned;
                     x.IsWordInProcessStuding = false;
                     x.IsWordRepeat = true;
                     x.TimeWordBecameLearned = DateTime.Now;
                 });
            _ctx.SaveChanges();
        }
        public void SetToWordsStatusAsUnlearned(int dictionaryId)
        {
            _ctx.Words.Where(x => x.Dictionary.Id == dictionaryId)
                      .ToList()
                      .ForEach(x => {
                          x.IsWordLearned = false;
                          x.IsCardPassed = CardsIsNotLearned;
                          x.IsWordInProcessStuding = false;
                          x.IsWordRepeat = false;
                          x.TimeWordBecameLearned = default(DateTime);
                      });
            _ctx.SaveChanges();
        }
        public void SetToWordsStatusAsRepeated(int[] wordsId)
        {
            _ctx.Words.Where(x => wordsId.Contains(x.Id))
                      .ToList()
                      .ForEach(x =>
                      {
                          x.IsWordRepeat = true;
                          x.TimeWordBecameLearned = DateTime.Now;
                      });
            _ctx.SaveChanges();
        }
        public void ChangeImage(int wordId, byte[] newImage)
        {
            _ctx.Words.Where(x => x.Id == wordId)
                      .SingleOrDefault()
                      .Image = newImage;
            _ctx.SaveChanges();
        }
        public void ChangeSound(int wordId, byte[] newSound)
        {
            _ctx.Words.Where(x => x.Id == wordId)
                      .SingleOrDefault()
                      .Sound = newSound;
            _ctx.SaveChanges();
        }
        public bool AddDictionary(DictionaryExtn dictionary)
        {
            int countBefore = _ctx.Dictionaries.Count();
            _ctx.Dictionaries.Add(dictionary);
            _ctx.SaveChanges();
            int countAfter = _ctx.Dictionaries.Count();
            return countAfter > countBefore;
        }
        public void UpdateDictionary(int dictionaryId, string newDictionaryName)
        {
            _ctx.Dictionaries.Where(x => x.Id == dictionaryId)
                             .SingleOrDefault()
                             .Name = newDictionaryName;
            _ctx.SaveChanges();
        }
        public bool DeleteDictionary(int dictionaryId)
        {
            int countBefore = _ctx.Dictionaries.Count();
            _ctx.Dictionaries.Remove(GetDictionary(dictionaryId));
            _ctx.SaveChanges();
            int countAfter = _ctx.Dictionaries.Count();
            return countBefore > countAfter;
        }
        public DictionaryExtn GetDictionary(int dictionaryId)
        {
            return _ctx.Dictionaries.Where(x => x.Id == dictionaryId)
                                    .SingleOrDefault();
        }
        public List<Dictionary> GetDictionariesBaseInfo(int userId)
        {
            List<Dictionary> listDictionaries = new List<Dictionary>();
            _ctx.Dictionaries.Where(x => x.Credential.Id == userId)
                             .ToList()
                             .ForEach(x => listDictionaries.Add(new Dictionary
                             {
                                 Id = x.Id,
                                 Name = x.Name
                             }));
            return listDictionaries;
        }
        public bool StartInitializeDictionary(DictionaryExtn dictionary)
        {
            string path = Path.GetTempPath();
            int countBefore = _ctx.Words.Count();
            _ctx.Words.AddRange(new List<Word>
            {
                new Word
                {
                    WordEng = "cat",
                    Transcription = "|kæt|",
                    Translation = "кіт",
                    Dictionary = dictionary,
                    Image = File.ReadAllBytes($@"{path}\Image\cat.jpg"),
                    Sound = File.ReadAllBytes($@"{path}\Sound\cat.mp3"),
                    IsCardPassed = CardsIsNotLearned
                },
                new Word
                {
                    WordEng = "dog",
                    Transcription = "|dɔːɡ|",
                    Translation = "пес",
                    Dictionary = dictionary,
                    Image = File.ReadAllBytes($@"{path}\Image\dog.jpg"),
                    Sound = File.ReadAllBytes($@"{path}\Sound\dog.mp3"),
                    IsCardPassed = CardsIsNotLearned
                },
                new Word
                {
                    WordEng = "bear",
                    Transcription = "|ber|",
                    Translation = "ведмідь",
                    Dictionary = dictionary,
                    Image = File.ReadAllBytes($@"{path}\Image\bear.jpeg"),
                    Sound = File.ReadAllBytes($@"{path}\Sound\bear.mp3"),
                    IsCardPassed = CardsIsNotLearned
                },
                new Word
                {
                    WordEng = "penguin",
                    Transcription = "|ˈpeŋɡwɪn|",
                    Translation = "пінгвін",
                    Dictionary = dictionary,
                    Image = File.ReadAllBytes($@"{path}\Image\penguin.png"),
                    Sound = File.ReadAllBytes($@"{path}\Sound\penguin.mp3"),
                    IsCardPassed = CardsIsNotLearned
                },
                new Word
                {
                    WordEng = "parrot",
                    Transcription = "|ˈpærət|",
                    Translation = "папуга",
                    Dictionary = dictionary,
                    Image = File.ReadAllBytes($@"{path}\Image\parrot.png"),
                    Sound = File.ReadAllBytes($@"{path}\Sound\parrot.mp3"),
                    IsCardPassed = CardsIsNotLearned
                },
                new Word
                {
                    WordEng = "donkey",
                    Transcription = "|ˈdɔːŋki|",
                    Translation = "осел",
                    Dictionary = dictionary,
                    Image = File.ReadAllBytes($@"{path}\Image\donkey.jpg"),
                    Sound = File.ReadAllBytes($@"{path}\Sound\donkey.mp3"),
                    IsCardPassed = CardsIsNotLearned
                },
                new Word
                {
                    WordEng = "rat",
                    Transcription = "|ræt|",
                    Translation = "пацюк",
                    Dictionary = dictionary,
                    Image = File.ReadAllBytes($@"{path}\Image\rat.png"),
                    Sound = File.ReadAllBytes($@"{path}\Sound\rat.mp3"),
                    IsCardPassed = CardsIsNotLearned
                },
                new Word
                {
                    WordEng = "mosquito",
                    Transcription = "|məˈskiːtoʊ|",
                    Translation = "комар",
                    Dictionary = dictionary,
                    Image = File.ReadAllBytes($@"{path}\Image\mosquito.jpg"),
                    Sound = File.ReadAllBytes($@"{path}\Sound\mosquito.mp3"),
                    IsCardPassed = CardsIsNotLearned
                },
                new Word
                {
                    WordEng = "fox",
                    Transcription = "|fɑːks|",
                    Translation = "лисиця",
                    Dictionary = dictionary,
                    Image = File.ReadAllBytes($@"{path}\Image\fox.png"),
                    Sound = File.ReadAllBytes($@"{path}\Sound\fox.mp3"),
                    IsCardPassed = CardsIsNotLearned
                },
                new Word
                {
                    WordEng = "ratel",
                    Transcription = "|ˈreɪt(ə)l|",
                    Translation = "медоїд",
                    Dictionary = dictionary,
                    Image = File.ReadAllBytes($@"{path}\Image\ratel.jpg"),
                    Sound = File.ReadAllBytes($@"{path}\Sound\ratel.mp3"),
                    IsCardPassed = CardsIsNotLearned
                }
            });
            _ctx.SaveChanges();
            int countAfter = _ctx.Words.Count();
            return countAfter > countBefore;
        }
    }
}