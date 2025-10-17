using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTests
{
    [CollectionDefinition("Global Test Collection")]
    public class GlobalTestCollection : ICollectionFixture<IdGeneratorFixture>
    {
    }
}
