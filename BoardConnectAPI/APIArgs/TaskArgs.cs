namespace BoardConnectAPI
{
    public class TaskArgs : BaseArgs
    {
        #region Public Properties

        /// <summary>
        /// By Title
        /// </summary>
        public string Search { get; set; }

        /// <summary>
        /// By status type
        /// </summary>
        public StatusType? StatusType { get; set; }

        /// <summary>
        /// By min progress
        /// </summary>
        public decimal MinProgress { get; set; }

        /// <summary>
        /// By max progress
        /// </summary>
        public decimal MaxProgress { get; set; }

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

        /// <summary>
        /// By included projects
        /// </summary>
        public IEnumerable<int> IncludedProjects { get; set; }

        /// <summary>
        /// By excluded projects
        /// </summary>
        public IEnumerable<int> ExcludedProjects { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public TaskArgs() : base()
        {

        }

        #endregion
    }
}
