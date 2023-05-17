namespace BoardConnectAPI
{
    public class TaskResponseModel : DateResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The progress
        /// </summary>
        public decimal Progress { get; set; }

        /// <summary>
        /// The status
        /// </summary>
        public StatusType Status { get; set; }

        /// <summary>
        /// The start date
        /// </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// The finish date
        /// </summary>
        public DateTimeOffset FinishDate { get; set; }

        /// <summary>
        /// The related <see cref="ProjectResponseModel"/>
        /// </summary>
        /// The related company
        /// Navigation Property
        public ProjectResponseModel Project { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public TaskResponseModel() : base()
        {

        }

        #endregion
    }
}
