
using Enterprise.Model;

namespace Enterprise.Persistence.Dao.Mapping
{
    internal class ClassroomMap : EntityBaseMap<Classroom>
    {
        public ClassroomMap()
        {
            Map(classroom => classroom.Name);
            Map(classroom => classroom.Desks);

            References(classroom => classroom.Teacher);
            HasMany(classroom => classroom.Students);
        }
    }
}
