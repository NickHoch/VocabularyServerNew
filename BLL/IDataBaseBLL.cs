﻿using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IDataBaseBLL
    {

        bool IsEmailAddressExists(string email);
        bool IsDictionaryNameExists(string dictionaryName, int userId);
        int? GetUserIdByCredential(CredentialDTO credentialDTO);
        bool AddUser(CredentialExtnDTO credentialDTO);
        bool AddWord(WordDTO wordDTO, int dictionaryId);
        bool DeleteWord(int wordId);
        void UpdateWord(WordDTO wordDTO);
        List<WordDTO> GetWords(int dictionaryId);
        List<WordDTO> GetNotLearnedWords(int quantityWords, int dictionaryId);
        void SetToWordsStatusAsLearned(int quantityWords, int dictionaryId);
        void SetToWordsStatusAsUnlearned(int dictionaryId);
        void ChangeImage(int wordId, byte[] newImage);
        void ChangeSound(int wordId, byte[] newSound);
        bool AddDictionary(DictionaryExtnDTO dictionaryDTO, int userId);
        void UpdateDictionary(int dictionaryId, string newDictionaryName);
        bool DeleteDictionary(int dictionaryId);
        List<DictionaryDTO> GetDictionariesBaseInfo(int userId);
        void ChangeStatusCards(Dictionary<int, bool[]> newCardsStatuses, int dictionaryId);
    }
}
