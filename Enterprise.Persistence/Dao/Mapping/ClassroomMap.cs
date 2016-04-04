
using Enterprise.Model;

namespace Enterprise.Persistence.Dao.Mapping
{
    class ClassroomMap : EntityBaseMap<Classroom>
    {
        public ClassroomMap()
        {
            Map(classroom => classroom.Desks);
            References(classroom => classroom.Teacher);
            HasMany(classroom => classroom.Students);
        }
    }
}
