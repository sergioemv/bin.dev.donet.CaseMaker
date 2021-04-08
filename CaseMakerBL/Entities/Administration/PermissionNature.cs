namespace CaseMaker.Entities.Administration
{
    public enum PermissionNature
    {
        /// <summary>
        /// Read And write permissons
        /// </summary>
        FULL,
        /// <summary>
        /// Only read permission
        /// </summary>
        READONLY,
        /// <summary>
        /// The user owns the test object
        /// </summary>
        OWNER,
    }
}