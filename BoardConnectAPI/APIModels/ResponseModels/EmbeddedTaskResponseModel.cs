namespace BoardConnectAPI
{
    public class EmbeddedTaskResponseModel : BaseResponseModel
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Title"/> property
        /// </summary>
        private string? mTitle;

        /// <summary>
        /// The member of the <see cref="Description"/> property
        /// </summary>
        private string? mDescription;

        #endregion

        #region Public Properties

        /// <summary>
        /// The title
        /// </summary>
        public string Title
        {
            get => mTitle ?? string.Empty;

            set => mTitle = value;
        }

        /// <summary>
        /// The description
        /// </summary>
        public string Description
        {
            get => mDescription ?? string.Empty;

            set => mDescription = value;
        }

        /// <summary>
        /// The progress
        /// </summary>
        public uint Progress { get; set; }

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
