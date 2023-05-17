namespace BoardConnectAPI
{
    public abstract class BaseArgs
    {
        #region Public Properties

        /// <summary>
        /// The page
        /// </summary>
        public int Page { get; set; } = 0;

        /// <summary>
        /// Per page
        /// </summary>
        public int PerPage { get; set; } = 10;

        /// <summary>
        /// By after date created
        /// </summary>
        public DateTimeOffset? AfterDateCreated { get; set; }

        /// <summary>
        /// By before date created
        /// </summary>
        public DateTimeOffset? BeforeDateCreated { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseArgs() : base()
        {

        }

        #endregion
    }
}
