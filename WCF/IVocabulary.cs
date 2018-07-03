using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF.DCs;

namespace WCF
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface IVocabulary
    {
        [OperationContract]
        bool IsDictionaryNameExists(string email, int userId);
        [OperationContract]
        bool IsEmailAddressExists(string email);
        [OperationContract]
        int? GetUserIdByCredential(CredentialDC credentialDC);
        [OperationContract]
        bool AddUser(CredentialExtnDC credentialDC);
        [OperationContract]
        bool AddWord(WordDC wordDC, int dictionaryId);
        [OperationContract]
        bool DeleteWord(int wordId);
        [OperationContract]
        void UpdateWord(WordDC wordDC);
        [OperationContract]
        ICollection<WordDC> GetWords(int dictionaryId);
        [OperationContract]
        ICollection<WordDC> GetNotLearnedWordsByUserId(int userId);
        [OperationContract]
        ICollection<WordDC> GetNotLearnedWords(int dictionaryId, int quantityWords);
        [OperationContract]
        ICollection<WordDC> GetWordsToRepeat(int userId);
        [OperationContract]
        int GetQuantityUnlearnedWordsInDictionary(int dictionaryId);
        [OperationContract]
        int? IsLearningProcessActive(int userId);
        [OperationContract]
        void ChangeOutstandingWords(int userId);
        [OperationContract]
        void ChangeStatusCards(Dictionary<int, string> newCardsStatuses, int dictionaryId);
        [OperationContract]
        void SetToWordsStatusAsLearned(int[] wordsId, int dictionaryId);
        [OperationContract]
        void SetToWordsStatusAsUnlearned(int dictionaryId);
        [OperationContract]
        void SetToWordsStatusAsRepeated(int[] wordsId);
        [OperationContract]
        void ChangeImage(int wordId, byte[] newImage);
        [OperationContract]
        void ChangeSound(int wordId, byte[] newSound);
        [OperationContract]
        bool AddDictionary(DictionaryExtnDC dictionaryDC, int userId);
        [OperationContract]
        void UpdateDictionary(int dictionaryId, string newDictionaryName);
        [OperationContract]
        bool DeleteDictionary(int dictionaryId);
        [OperationContract]
        ICollection<DictionaryDC> GetDictionariesBaseInfo(int userId);
    }
}