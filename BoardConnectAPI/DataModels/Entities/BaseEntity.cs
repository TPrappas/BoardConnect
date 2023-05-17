namespace BoardConnectAPI
{
    public abstract class BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// The Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// The Date Created
        /// </summary>
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// The Date Modified
        /// </summary>
        public DateTimeOffset DateUpdated { get; set;}

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseEntity() : base()
        {
                
        }

        #endregion
    }
}
