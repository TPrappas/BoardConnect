namespace BoardConnectAPI.APIArgs
{
    public class ProjectArgs : BaseArgs
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Search"/> property
        /// </summary>
        private string? mSearch;

        /// <summary>
        /// The member of the <see cref="Name"/> property
        /// </summary>
        private string? mName;

        #endregion

        #region Public Properties

        /// <summary>
        /// By Title
        /// </summary>
        public string Search
        {
            get => mSearch ?? string.Empty;

            set => mSearch = value;
        }

        /// <summary>
        /// By name
        /// </summary>
        public string Name
        {
            get => mName ?? string.Empty;

            set => mName = value;
        }

        /// <summary>
        /// By min progress
        /// </summary>
        public decimal? MinProgress { get; set; }

        /// <summary>
        /// By max progress
        /// </summary>
        public decimal? MaxProgress { get; set; }

        /// <summary>
        /// By after start date 
        /// </summary>
        public DateTimeOffset? AfterStartDate { get; set; }

        /// <summary>
        /// By before start date 
        /// </summary>
        public DateTimeOffset? BeforeStartDate { get; set; }

        /// <summary>
        /// By after date created
        /// </summary>
        public DateTimeOffset? AfterFinishDate { get; set; }

        /// <summary>
        /// By before date created
        /// </summary>
        public DateTimeOffset? BeforeFinishDate { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectArgs() : base()
        {

        }

        #endregion

    }
}
