using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Run.Azurite.NET.Commands.Concrete;
using System.Diagnostics;

namespace Run.Azurite.NET.Tests.Commands.Concrete
{
    [TestClass]
    public class WindowsCommandTest
    {
        [TestMethod]
        public void RunShouldInvokeProxyStartWith_Cmd_CreateNoWindow_GivenCommandOnArguments()
        {
            string command = "echo '123'";
            Mock<IProcessProxy> mockedProcessProxy = new();
            mockedProcessProxy.Setup(proxy => proxy.Start(It.IsAny<ProcessStartInfo>())).Returns(true);

            WindowsCommand windowsCommand = new(mockedProcessProxy.Object);

            Assert.IsTrue(windowsCommand.Run(command));
            
            mockedProcessProxy.Verify(processProxy 
                => processProxy.Start(
                        It.Is<ProcessStartInfo>(
                            info => info.FileName == "cmd.exe" 
                            && info.CreateNoWindow == true
                            && info.Arguments == "echo '123'")
                )
            );
        }
    }
}
