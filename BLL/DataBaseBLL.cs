using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.DTOs;
using BLL.Mapping;
using DAL.Models;

namespace BLL
{
    public class DataBaseBLL
    {
        DataBaseDAL _dal = new DataBaseDAL();
        public bool IsEmailAddressExists(string email)
        {
            return _dal.IsEmailAddressExists(email);
        }
        public bool IsDictionaryNameExists(string dictionaryName, int userId)
        {
            return _dal.IsDictionaryNameExists(dictionaryName, userId);
        }
        public int? GetUserIdByCredential(CredentialDTO credentialDTO)
        {
            var credential = MappingCredential.MappingDTOtoDM(credentialDTO);
            return _dal.GetUserIdByCredential(credential);
        }
        public bool AddUser(CredentialExtnDTO credentialDTO)
        {
            bool resAddUser = false;
            var credential = MappingCredentialExtn.MappingDTOtoDM(credentialDTO);
            var resAddCred = _dal.AddCredential(credential);
            if(resAddCred)
            {
                DictionaryExtn dictionary = new DictionaryExtn
                {
                    Name = "Animals",
                    Credential = credential
                };
                var resAddDict = _dal.AddDictionary(dictionary);
                if(resAddDict)
                {
                    resAddUser = _dal.StartInitializeDictionary(dictionary);
                }
            }
            return resAddUser;
        }
        public bool AddWord(WordDTO wordDTO, int dictionaryId)
        {
            var word = MappingWord.MappingDTOtoDM(wordDTO);
            word.Dictionary = _dal.GetDictionary(dictionaryId);
            return _dal.AddWord(word);
        }
        public bool DeleteWord(int wordId)
        {
            return _dal.DeleteWord(wordId);
        }
        public void UpdateWord(WordDTO wordDTO)
        {
            var word = MappingWord.MappingDTOtoDM(wordDTO);
            _dal.UpdateWord(word);
        }
        public List<WordDTO> GetWords(int dictionaryId)
        {
            List<WordDTO> listWordsDTO = new List<WordDTO>();
            var listWords = _dal.GetWords(dictionaryId);
            listWords.ForEach(x => listWordsDTO.Add(MappingWord.MappingDMtoDTO(x)));
            return listWordsDTO;
        }
        public List<WordDTO> GetNotLearnedWords(int quantityWords, int dictionaryId)
        {
            List<WordDTO> listWordsDTO = new List<WordDTO>();
            var listWords = _dal.GetNotLearnedWords(quantityWords, dictionaryId);
            listWords.ForEach(x => listWordsDTO.Add(MappingWord.MappingDMtoDTO(x)));
            return listWordsDTO;
        }
        public void SetToWordsStatusAsLearned(int quantityWords, int dictionaryId)
        {
            _dal.SetToWordsStatusAsLearned(quantityWords, dictionaryId);
        }
        public void SetToWordsStatusAsUnlearned(int dictionaryId)
        {
            _dal.SetToWordsStatusAsUnlearned(dictionaryId);
        }
        public void ChangeImage(int wordId, byte[] newImage)
        {
            _dal.ChangeImage(wordId, newImage);
        }
        public void ChangeSound(int wordId, byte[] newSound)
        {
            _dal.ChangeSound(wordId, newSound);
        }
        public bool AddDictionary(DictionaryExtnDTO dictionaryDTO, int userId)
        {
            var dictionary = MappingDictionaryExtn.MappingDTOtoDM(dictionaryDTO);
            dictionary.Credential = _dal.GetCredentialById(userId);
            return _dal.AddDictionary(dictionary);
        }
        public void UpdateDictionary(int dictionaryId, string newDictionaryName)
        {
            _dal.UpdateDictionary(dictionaryId, newDictionaryName);
        }
        public bool DeleteDictionary(int dictionaryId)
        {
            return _dal.DeleteDictionary(dictionaryId);
        }
        public List<DictionaryDTO> GetDictionariesBaseInfo(int userId)
        {
            List<DictionaryDTO> listDictionariesDTO = new List<DictionaryDTO>();
            var listDictionaries = _dal.GetDictionariesBaseInfo(userId);
            listDictionaries.ForEach(x => listDictionariesDTO.Add(MappingDictionary.MappingDMtoDTO(x)));
            return listDictionariesDTO;
        }
    }
}