namespace BoardConnectAPI
{
    public abstract class BaseResponseModel
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        public int Id { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseResponseModel() : base()
        {

        }

        #endregion
    }
}
