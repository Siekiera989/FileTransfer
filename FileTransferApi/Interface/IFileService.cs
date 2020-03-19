using System.Threading.Tasks;

namespace FileTransferApi.Interface
{
    public interface IFileService
    {
        void EnterIntoFile(string someText, string fileName = "testFile.txt");
    }
}
