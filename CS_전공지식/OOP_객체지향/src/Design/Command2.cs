namespace DesignPattern
{
    public interface ElectronicDevice
    {
        public void On();
        public void Off();
        public void VolumeUp();
        public void VolumeDown();
    }

    //리시버
    public class Television : ElectronicDevice {
        private int volume = 0;
        public void On(){
            Console.WriteLine("TV is On");
            }
        public void Off(){
            Console.WriteLine("TV is Off");
            }
        public void VolumeUp(){
            this.volume++;
            Console.WriteLine($"TV Volume is at {this.volume}");
            }
        public void VolumeDown(){
            this.volume--;
            Console.WriteLine($"TV Volume is at {this.volume}");
            }
    }

    //리시버
    public class Radio : ElectronicDevice {
        private int volume = 0;
        public void On(){
            Console.WriteLine("Radio is On");
            }
        public void Off(){
            Console.WriteLine("Radio is Off");
            }
        public void VolumeUp(){
            this.volume++;
            Console.WriteLine($"Radio Volume is at {this.volume}");
            }
        public void VolumeDown(){
            this.volume--;
            Console.WriteLine($"Radio Volume is at {this.volume}");
            }
    }

    //커맨드
    public interface Command {
        public void Execute();
    }

    //콘크리트 커맨드
    public class TurnTvOn : Command {
        private ElectronicDevice electronicDevice;
        public TurnTvOn(ElectronicDevice electronicDevice){
            this.electronicDevice = electronicDevice;
        }

        public void Execute(){
            electronicDevice.On();
        }
    } 

    //콘크리트 커맨드
    public class TurnTvOff : Command {
        private ElectronicDevice electronicDevice;
        public TurnTvOff(ElectronicDevice electronicDevice){
            this.electronicDevice = electronicDevice;
        }

        public void Execute(){
            electronicDevice.Off();
        }
    }

    public class TurnAllDevices : Command {
        List<ElectronicDevice> electroDevices;
        public TurnAllDevices() {
            this.electroDevices = new List<ElectronicDevice>();
        }
        public TurnAllDevices AddDevices(ElectronicDevice electronicDevice){
            this.electroDevices.Add(electronicDevice);
            return TurnAllDevices;
        }

        public void Execute(){
            foreach(ElectronicDevice E in this.electroDevices){E.Off();}
        }
    }

    //콜러 || 인보커
    public class DeviceButton{
        Command theCommand;
        public DeviceButton(Command command){
            this.theCommand = command;
        }
        public void Press(){
            theCommand.Execute();
        }
    }

    static void Main(string argv) {
        ElectronicDevice tv = new Television();

        TurnTvOn onCommand = new TurnTvOn(tv);
        TurnTvOff offCommand = new TurnTvOff(tv);

        DeviceButton onButton= new DeviceButton(onCommand);

        onButton.Press();
        onButton = new DeviceButton(offCommand);
        onButton.Press();

        ElectronicDevice radio = new Radio();

        TurnAllDevices allOffCommand= new TurnAllDevices();
        allOffCommand.AddDevices(radio).AddDevices(tv);

        onButton = new DeviceButton(allOffCommand);
        onButton.Press();
    }
} 