using Enterprise.Model;

namespace Enterprise.Persistence.Dao.Mapping
{
    internal class TeacherMap : EntityBaseMap<Teacher>
    {
        public TeacherMap()
        {
            Map(teacher => teacher.FullName);
            Map(teacher => teacher.Birthday);

            References(teacher => teacher.Classroom);
        }
    }
}
