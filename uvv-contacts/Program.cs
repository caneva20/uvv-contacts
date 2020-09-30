using System.Threading.Tasks;
using caneva20.CircularList;

namespace caneva20 {
    class Program {
        private static async Task Main(string[] args) {
            var list = new CircularList<int>();

            for (var i = 0; i < 10; i++) {
                list.Add(i);
            }
            
            list.Remove(5);

            var a = "";
        }
    }
}
