using System;
using System.Collections.Generic;
using System.Text;
using GenericValidator;

namespace Test
{
    public class ValidateProfile : Profile
    {
        public ValidateProfile()
        {
            CreateConfig<Student>()
                .ForProperty(s => s.Age, opt => opt.Number(1, 20))
                .ForProperty(s => s.Name, opt => opt.String(1, 3));
            CreateConfig<Teacher>()
                .ForProperty(t => t.Age, opt => opt.Number(1, 50))
                .ForProperty(t => t.Name, opt => opt.String(1, 5));
            CreateConfig<Group>()
                .ForProperty(g => g.Name, opt => opt.String(1, 5))
                .ForProperty(g => g.StudentsCount, opt => opt.Number(4, 10))
                .ForPropertyCustoms(g => g.Id, MyCustomValidator.IdGuid);
        }
    }
}
