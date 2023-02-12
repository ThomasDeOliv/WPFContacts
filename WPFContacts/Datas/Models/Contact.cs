using SQLite;

namespace WPFContacts.Datas.Models
{
    [Table("contact")]
    public class Contact
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        [Column("name"), NotNull, MaxLength(50)]
        public string Name { get; set; }

        [Column("firstname"), NotNull, MaxLength(50)]
        public string FirstName { get; set; }

        [Column("phone"), NotNull, Unique, MaxLength(50)]
        public string Phone { get; set; }

        [Column("mail"), Unique, MaxLength(320)]
        public string Mail { get; set; }
    }
}
