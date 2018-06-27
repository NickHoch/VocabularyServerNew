using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml;
using System.Xml.Serialization;
using DAL.Models;

namespace DAL
{
    internal class CustomInitializer<T> : DropCreateDatabaseAlways<VocabularyModel>
    {
        protected override void Seed(VocabularyModel _ctx)
        {
            string path = Path.GetTempPath();
            #region
            CredentialExtn cred1 = new CredentialExtn
            {
                Email = "kolya.goch@gmail.com",
                Password = "kolyagoch1234"
            };
            _ctx.Credentials.Add(cred1);
            DictionaryExtn dict1 = new DictionaryExtn
            {
                Name = "Animal",
                Credential = cred1
            };
            _ctx.Dictionaries.Add(dict1);
            Word[] words = new Word[]
            {
                new Word
                {
                    WordEng = "cat",
                    Transcription = "|kæt|",
                    Translation = "кіт",
                    Dictionary = dict1,
                    Image = File.ReadAllBytes($@"{path}\Image\cat.jpg"),
                    Sound = File.ReadAllBytes($@"{path}\Sound\cat.mp3"),
                    IsWordLearned = false
                },
                new Word
                {
                    WordEng = "dog",
                    Transcription = "|dɔːɡ|",
                    Translation = "пес",
                    Dictionary = dict1,
                    Image = File.ReadAllBytes($@"{path}\Image\dog.jpg"),
                    Sound = File.ReadAllBytes($@"{path}\Sound\dog.mp3"),
                    IsWordLearned = false
                },
                new Word
                {
                    WordEng = "bear",
                    Transcription = "|ber|",
                    Translation = "ведмідь",
                    Dictionary = dict1,
                    Image = File.ReadAllBytes($@"{path}\Image\bear.jpeg"),
                    Sound = File.ReadAllBytes($@"{path}\Sound\bear.mp3"),
                    IsWordLearned = false
                },
                new Word
                {
                    WordEng = "penguin",
                    Transcription = "|ˈpeŋɡwɪn|",
                    Translation = "пінгвін",
                    Dictionary = dict1,
                    Image = File.ReadAllBytes($@"{path}\Image\penguin.png"),
                    Sound = File.ReadAllBytes($@"{path}\Sound\penguin.mp3"),
                    IsWordLearned = false
                },
                new Word
                {
                    WordEng = "parrot",
                    Transcription = "|ˈpærət|",
                    Translation = "папуга",
                    Dictionary = dict1,
                    Image = File.ReadAllBytes($@"{path}\Image\parrot.png"),
                    Sound = File.ReadAllBytes($@"{path}\Sound\parrot.mp3"),
                    IsWordLearned = false
                },
                new Word
                {
                    WordEng = "donkey",
                    Transcription = "|ˈdɔːŋki|",
                    Translation = "осел",
                    Dictionary = dict1,
                    Image = File.ReadAllBytes($@"{path}\Image\donkey.jpg"),
                    Sound = File.ReadAllBytes($@"{path}\Sound\donkey.mp3"),
                    IsWordLearned = false
                },
                new Word
                {
                    WordEng = "rat",
                    Transcription = "|ræt|",
                    Translation = "пацюк",
                    Dictionary = dict1,
                    Image = File.ReadAllBytes($@"{path}\Image\rat.png"),
                    Sound = File.ReadAllBytes($@"{path}\Sound\rat.mp3"),
                    IsWordLearned = false
                },
                new Word
                {
                    WordEng = "mosquito",
                    Transcription = "|məˈskiːtoʊ|",
                    Translation = "комар",
                    Dictionary = dict1,
                    Image = File.ReadAllBytes($@"{path}\Image\mosquito.jpg"),
                    Sound = File.ReadAllBytes($@"{path}\Sound\mosquito.mp3"),
                    IsWordLearned = false
                },
                new Word
                {
                    WordEng = "fox",
                    Transcription = "|fɑːks|",
                    Translation = "лисиця",
                    Dictionary = dict1,
                    Image = File.ReadAllBytes($@"{path}\Image\fox.png"),
                    Sound = File.ReadAllBytes($@"{path}\Sound\fox.mp3"),
                    IsWordLearned = false
                },
                new Word
                {
                    WordEng = "ratel",
                    Transcription = "|ˈreɪt(ə)l|",
                    Translation = "медоїд",
                    Dictionary = dict1,
                    Image = File.ReadAllBytes($@"{path}\Image\ratel.jpg"),
                    Sound = File.ReadAllBytes($@"{path}\Sound\ratel.mp3"),
                    IsWordLearned = false
                }
            };
            var serializer = new DataContractSerializer(typeof(Word[]),
                null,
                0x7FFF,
                false,
                true,
                null);
            using (FileStream fs = new FileStream($@"{path}\words.xml", FileMode.OpenOrCreate))
            {
                serializer.WriteObject(fs, words);
            }
            #endregion
            //Word[] words = null;
            //var serializer = new DataContractSerializer(typeof(Word[]), null,
            //    0x7FFF,
            //    false,
            //    true,
            //    null);
            //using (FileStream fs = new FileStream($@"{path}\words.xml", FileMode.OpenOrCreate))
            //{
            //    XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas()
            //    {
            //        MaxArrayLength = 2147483647
            //    });
            //    words = (Word[])serializer.ReadObject(reader);
            //    reader.Close();
            //}
            _ctx.Words.AddRange(words);
            _ctx.SaveChanges();
        }
    }
}