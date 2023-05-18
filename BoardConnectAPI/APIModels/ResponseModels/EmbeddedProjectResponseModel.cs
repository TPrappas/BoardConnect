namespace BoardConnectAPI
{
    public class EmbeddedProjectResponseModel : BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The discription
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The progress
        /// </summary>
        public decimal Progress { get; set; }

        /// <summary>
        /// The start date
        /// </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// The finish date
        /// </summary>
        public DateTimeOffset FinishDate { get; set; }

        /// <summary>
        /// The Tasks related to the project
        /// </summary>
        public IEnumerable<EmbeddedTaskResponseModel> Tasks { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmbeddedProjectResponseModel() : base()
        {

        }

        #endregion
    }
}
