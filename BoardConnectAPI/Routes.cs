namespace BoardConnectAPI
{
    public class Routes
    {
        /// <summary>
        /// The home route
        /// </summary>
        public const string HomeRoute = "api";

        #region Project Routes

        public const string ProjectsRoute = HomeRoute + "/projects";

        public const string ProjectRoute = ProjectsRoute + "/{projectId}";

        #endregion

        #region Task Routes

        public const string TasksRoute = HomeRoute + "/tasks";

        public const string TaskRoute = TasksRoute + "/{taskId}";

        #endregion
    }
}
