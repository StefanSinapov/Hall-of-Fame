namespace HallOfFame.Web.ViewModels.Shared
{
    using System.Collections.Generic;

    public class TimelineViewModel<T>
    {
        public int CurrentCount { get; set; }

        public ICollection<T> Collection { get; set; } 
    }
}