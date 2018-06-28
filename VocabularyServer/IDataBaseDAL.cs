using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDataBaseDAL
    {
        bool IsEmailAddressExists(string email);
        bool IsDictionaryNameExists(string dictionaryName, int userId);
        int? GetUserIdByCredential(Credential credential);
        CredentialExtn GetCredentialById(int userId);
        bool AddCredential(CredentialExtn credential);
        bool AddWord(Word word);
        bool DeleteWord(int wordId);
        void UpdateWord(Word newWord);
        List<Word> GetWords(int dictionaryId);
        List<Word> GetNotLearnedWords(int quantityWords, int dictionaryId);
        void SetToWordsStatusAsLearned(int[] wordsId, int dictionaryId);
        void SetToWordsStatusAsUnlearned(int dictionaryId);
        void ChangeImage(int wordId, byte[] newImage);
        void ChangeSound(int wordId, byte[] newSound);
        bool AddDictionary(DictionaryExtn dictionary);
        void UpdateDictionary(int dictionaryId, string newDictionaryName);
        bool DeleteDictionary(int dictionaryId);
        DictionaryExtn GetDictionary(int dictionaryId);
        List<Dictionary> GetDictionariesBaseInfo(int userId);
        bool StartInitializeDictionary(DictionaryExtn dictionary);
        void ChangeStatusCards(Dictionary<int, bool[]> newCardsStatuses, int dictionaryId);

    }
}
