namespace BoardConnectAPI
{
    public class TaskRequestModel : BaseRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The title
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The progress
        /// </summary>
        public uint? Progress { get; set; }

        /// <summary>
        /// The status
        /// </summary>
        public StatusType? Status { get; set; }

        /// <summary>
        /// The start date
        /// </summary>
        public DateTimeOffset? StartDate { get; set; }

        /// <summary>
        /// The finish date
        /// </summary>
        public DateTimeOffset? FinishDate { get; set; }

        /// <summary>
        /// The <see cref="BaseEntity.Id"/> of the related <see cref="ProjectEntity"/>
        /// </summary>
        /// The id of the related company
        public int? ProjectId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public TaskRequestModel() : base()
        {

        }

        #endregion
    }
}
