using System;

namespace BookService.WebAPI.Models
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        // in db default value getdate() --> BookServiceContext (object enter db from other ways)

        // program logic: date of creating the object
        private DateTime? created;
        public DateTime? Created {
            get
            {
                return created ?? DateTime.Now;
            }

            set {
                if (value != null)
                    created = value;
                else created = DateTime.Now;
            }
        }
    }
}
