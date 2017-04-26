using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Majorizor.Resources.DataAccess
{
    public class CourseInformation
    {
        /// <summary>
        /// Class mapping for when you only need subject, catalog, and name in the object
        /// </summary>
        /// <param name="_dr">DataRow containing fields `subject`, `catalog`, and `name`</param>
        /// <returns>a Course object with subject, catalog, and name initialized</returns>
        public static Course partial_courseinfoClassMapping(DataRow _dr)
        {
            string subject = _dr["subject"].ToString();
            string catalog = _dr["catalog"].ToString();
            string name = _dr["name"].ToString();
            return new Course(subject, catalog, name);
        }

        /// <summary>
        /// Class mapping for full Course Object from database
        /// </summary>
        /// <param name="_dr"></param>
        /// <returns></returns>
        private static Course courseClassMapping(DataRow _dr)
        {
            throw new NotImplementedException();
        }
    }
}