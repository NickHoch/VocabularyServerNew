namespace DAL
{
    using DAL.Models;
    using System.Data.Entity;

    public class VocabularyModel : DbContext
    {
        public VocabularyModel() : base("name=VocabularyModel")
        {
            Database.SetInitializer<VocabularyModel>(new CustomInitializer<VocabularyModel>());
        }
        public virtual DbSet<Word> Words { get; set; }
        public virtual DbSet<CredentialExtn> Credentials { get; set; }
        public virtual DbSet<DictionaryExtn> Dictionaries { get; set; }
    }
}