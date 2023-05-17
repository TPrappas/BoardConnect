using AutoMapper;

namespace BoardConnectAPI
{
    public class DI
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="GetMapper"/> property
        /// </summary>
        private static IMapper mMapper;

        #endregion

        #region Public Properties

        /// <summary>
        /// The host
        /// </summary>
        public static IHost Host { get; set; }

        /// <summary>
        /// The mapper
        /// </summary>
        public static IMapper GetMapper
        {
            get
            {
                if (mMapper == null)
                    mMapper = Host.Services.GetRequiredService<Mapper>();

                return mMapper;
            }
        }

        #endregion
    }
}
