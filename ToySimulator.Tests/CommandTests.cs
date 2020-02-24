using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using ToySimulator.Models;
using Xunit;

namespace ToySimulator.Tests
{
    
    public class CommandTests
    {
        Mock<IRobot> MockRobot;
        public CommandTests()
        {
            MockRobot = new Mock<IRobot>();
        }
        [Fact]
        public void Execute_Call_On_PlaceCommand_Calls_Robot_Place_Function()
        {

            MockRobot.Setup(x => x.Place(It.IsAny<IPosition>())).Returns(true);

            var mockPlaceCommand = new PlaceCommand(MockRobot.Object);
            mockPlaceCommand.Execute();

            MockRobot.Verify(x => x.Place(It.IsAny<IPosition>()), Times.Once);
        }

        [Fact]
        public void Execute_Call_On_MoveCommand_Calls_Robot_Move_Function()
        {
            MockRobot.Setup(x => x.Place(It.IsAny<IPosition>())).Returns(true);

            var moveCommand = new MoveCommand(MockRobot.Object);
            moveCommand.Execute();

            MockRobot.Verify(x => x.Move(), Times.Once);
        }

        [Fact]
        public void Execute_Call_On_LeftCommand_Calls_Robot_Left_Function()
        {
            MockRobot.Setup(x => x.Left()).Returns(true);

            var leftCommand = new LeftCommand(MockRobot.Object);
            leftCommand.Execute();

            MockRobot.Verify(x => x.Left(), Times.Once);
        }

        [Fact]
        public void Execute_Call_On_RightCommand_Calls_Robot_Right_Function()
        {
            MockRobot.Setup(x => x.Right()).Returns(true);

            var rightCommand = new RightCommand(MockRobot.Object);
            rightCommand.Execute();

            MockRobot.Verify(x => x.Right(), Times.Once);
        }

        [Fact]
        public void Execute_Call_On_ReportCommand_Calls_Robot_Report_Function()
        {
            MockRobot.Setup(x => x.Report()).Returns(true);

            var reportCommand = new ReportCommand(MockRobot.Object);
            reportCommand.Execute();

            MockRobot.Verify(x => x.Report(), Times.Once);
        }
    }
}
