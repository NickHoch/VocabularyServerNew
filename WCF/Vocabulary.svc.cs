using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BLL;
using WCF.DCs;
using WCF.Mapping;

namespace WCF
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Vocabulary : IVocabulary
    {
        private IDataBaseDAL _bll;
        public Vocabulary(IDataBaseDAL bll)
        {
            _bll = bll;
        }
        public bool IsEmailAddressExists(string email)
        {
            try
            {
                return _bll.IsEmailAddressExists(email);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        public bool IsDictionaryNameExists(string dictionaryName, int userId)
        {            
            try
            {
                return _bll.IsDictionaryNameExists(dictionaryName, userId);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        public int? GetUserIdByCredential(CredentialDC credentialDC)
        {
            try
            {
                var credentialDTO = MappingCredential.MappingDCtoDTO(credentialDC);
                return _bll.GetUserIdByCredential(credentialDTO);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        public bool AddUser(CredentialExtnDC credentialDC)
        {
            try
            {
                var credentialDTO = MappingCredentialExtn.MappingDCtoDTO(credentialDC);
                return _bll.AddUser(credentialDTO);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        public bool AddWord(WordDC wordDC, int dictionaryId)
        {
            try
            {
                var wordDTO = MappingWord.MappingDCtoDTO(wordDC);
                return _bll.AddWord(wordDTO, dictionaryId);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        public bool DeleteWord(int wordId)
        {
            try
            {
                return _bll.DeleteWord(wordId);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        public void UpdateWord(WordDC wordDC)
        {
            try
            {
                var wordDTO = MappingWord.MappingDCtoDTO(wordDC);
                _bll.UpdateWord(wordDTO);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        public ICollection<WordDC> GetWords(int dictionaryId)
        {
            try
            {
                List<WordDC> listWordsDC = new List<WordDC>();
                var listWordsDTO = _bll.GetWords(dictionaryId);
                listWordsDTO.ForEach(x => listWordsDC.Add(MappingWord.MappingDTOtoDC(x)));
                return listWordsDC;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        public ICollection<WordDC> GetNotLearnedWords(int quantityWords, int dictionaryId)
        {
            try
            {
                List<WordDC> listWordsDC = new List<WordDC>();
                var listWordsDTO = _bll.GetNotLearnedWords(quantityWords, dictionaryId);
                listWordsDTO.ForEach(x => listWordsDC.Add(MappingWord.MappingDTOtoDC(x)));
                return listWordsDC;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        public void SetToWordsStatusAsLearned(int quantityWords, int dictionaryId)
        {
            try
            {
                _bll.SetToWordsStatusAsLearned(quantityWords, dictionaryId);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        public void SetToWordsStatusAsUnlearned(int dictionaryId)
        {
            try
            {
                _bll.SetToWordsStatusAsUnlearned(dictionaryId);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        public void ChangeImage(int wordId, byte[] newImage)
        {
            try
            {
                _bll.ChangeImage(wordId, newImage);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        public void ChangeSound(int wordId, byte[] newSound)
        {
            try
            {
                _bll.ChangeSound(wordId, newSound);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        public bool AddDictionary(DictionaryExtnDC dictionaryDC, int userId)
        {
            try
            {
                var dictionaryDTO = MappingDictionaryExtn.MappingDCtoDTO(dictionaryDC);
                return _bll.AddDictionary(dictionaryDTO, userId);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        public void UpdateDictionary(int dictionaryId, string newDictionaryName)
        {
            try
            {
                _bll.UpdateDictionary(dictionaryId, newDictionaryName);
            }
            catch(Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        public bool DeleteDictionary(int dictionaryId)
        {
            try
            {
                return _bll.DeleteDictionary(dictionaryId);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        public ICollection<DictionaryDC> GetDictionariesBaseInfo(int userId)
        {
            try
            {
                List<DictionaryDC> listDictionariesDC = new List<DictionaryDC>();
                var listDictionariesDTO = _bll.GetDictionariesBaseInfo(userId);
                listDictionariesDTO.ForEach(x => listDictionariesDC.Add(MappingDictionary.MappingDTOtoDC(x)));
                return listDictionariesDC;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
    }
}