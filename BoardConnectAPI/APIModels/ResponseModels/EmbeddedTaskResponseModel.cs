namespace BoardConnectAPI
{
    public class EmbeddedTaskResponseModel : BaseResponseModel
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

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmbeddedTaskResponseModel() : base()
        {

        }

        #endregion
    }
}
