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
        ICollection<WordDC> GetNotLearnedWords(int quantityWords, int dictionaryId);
        [OperationContract]
        void ChangeStatusCards(Dictionary<int, bool[]> newCardsStatuses, int dictionaryId);
        [OperationContract]
        void SetToWordsStatusAsLearned(int[] wordsId, int dictionaryId);
        [OperationContract]
        void SetToWordsStatusAsUnlearned(int dictionaryId);
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