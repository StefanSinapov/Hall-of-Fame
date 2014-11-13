namespace HallOfFame.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HallOfFame.Data.Common.Models;

    public class Conversation : DeletableEntity
    {
        private ICollection<Message> messages;

        public Conversation()
        {
            this.messages = new HashSet<Message>();
        }

        [Key]
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<Message> Messages
        {
            get
            {
                return this.messages;
            }

            set
            {
                this.messages = value;
            }
        }
    }
}