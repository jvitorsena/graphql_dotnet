using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_dotnet.Entities
{
    public class BaseEntity
    {
        [Key] public Guid Id { get; set; }
        private DateTime? _createAt;

        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = (value == null ? DateTime.UtcNow : value); }
        }

        public DateTime updateAt { get; set; }
        public bool IsActive { get; set; }
    }
}