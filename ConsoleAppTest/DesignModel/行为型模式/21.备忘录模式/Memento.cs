using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.行为型模式._21.备忘录模式
{
    //备忘录模式
    //保存 某个对象 的 某个或某些 状态，以便 在 需要恢复到先前的某个状态的时候 可以 快速恢复。
    //在不破坏封装性的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态（如果没有这个关键点，其实深拷贝就可以解决这个问题）。这样在以后就可以将该对象恢复到原先保存的状态。

    //备份Originator的状态信息，并可以在某个时候通过备忘录Memento恢复Originator的状态信息。

    //角色：
    //1.发起人角色Originator：记录当前时刻的内部状态，负责创建和恢复备忘录数据。
    //2.备忘录角色Memento：负责存储发起人对象的内部状态，在进行恢复时提供给发起人需要的状态，并可以防止Originator以外的其他对象访问备忘录。
    //3.看守者角色Caretaker：负责保存和管理备忘录对象。

 //   备忘录模式的实现要点：
 //       备忘录（Memento）存储原发器（Originator）对象的内部状态，在需要时恢复原发器状态。Memento模式适用于“由原发器管理，却又必须存储在原发器之外的信息”。
　//　在实现Memento模式中，要防止原发器以外的对象访问备忘录对象。备忘录对象有两个接口，一个为原发器使用的宽接口；一个为其他对象使用的窄接口。在实现Memento模式时，要考虑拷贝对象状态的效率问题，如果对象开销比较大，可以采用某种增量式改变（即只记住改变的状态）来改进Memento模式。
　//　我们也可以用序列化的方式实现备忘录。序列化之后，我们可以把它临时性保存到数据库、文件、进程内、进程外等地方。
 //   （1）、备忘录模式的主要优点有：
 //           1】、如果某个操作错误地破坏了数据的完整性，此时可以使用备忘录模式将数据恢复成原来正确的数据。
 //           2】、备份的状态数据保存在发起人角色之外，这样发起人就不需要对各个备份的状态进行管理。而是由备忘录角色进行管理，而备忘录角色又是由管理者角色管理，符合单一职责原则。
 //           3】、提供了一种状态恢复的实现机制，使得用户可以方便地回到一个特定的历史步骤，当新的状态无效或者存在问题时，可以使用先前存储起来的备忘录将状态复原。
 //           4】、实现了信息的封装，一个备忘录对象是一种原发器对象的表示，不会被其他代码改动，这种模式简化了原发器对象，备忘录只保存原发器的状态，采用堆栈来存储备忘录对象可以实现多次撤销操作，可以通过在负责人中定义集合对象来存储多个备忘录。
 //           5】、本模式简化了发起人类。发起人不再需要管理和保存其内部状态的一个个版本，客户端可以自行管理他们所需要的这些状态的版本。
 //           6】、当发起人角色的状态改变的时候，有可能这个状态无效，这时候就可以使用暂时存储起来的备忘录将状态复原。
　//（2）、备忘录模式的主要缺点有：
 //           1】、在实际的系统中，可能需要维护多个备份，需要额外的资源，这样对资源的消耗比较严重。资源消耗过大，如果类的成员变量太多，就不可避免占用大量的内存，而且每保存一次对象的状态都需要消耗内存资源，如果知道这一点大家就容易理解为什么一些提供了撤销功能的软件在运行时所需的内存和硬盘空间比较大了。
 //           2】、如果发起人角色的状态需要完整地存储到备忘录对象中，那么在资源消耗上面备忘录对象会很昂贵。
　//　    3】、当负责人角色将一个备忘录 存储起来的时候，负责人可能并不知道这个状态会占用多大的存储空间，从而无法提醒用户一个操作是否很昂贵。
　//　    4】、当发起人角色的状态改变的时候，有可能这个协议无效。如果状态改变的成功率不高的话，不如采取“假如”协议模式。
 //   （3）、在下面的情况下可以考虑使用备忘录模式：
 //         1】、如果系统需要提供回滚操作时，使用备忘录模式非常合适。例如文本编辑器的Ctrl+Z撤销操作的实现，数据库中事务操作。
 //         2】、保存一个对象在某一个时刻的状态或部分状态，这样以后需要时它能够恢复到先前的状态。
 //         3】、如果用一个接口来让其他对象得到这些状态，将会暴露对象的实现细节并破坏对象的封装性，一个对象不希望外界直接访问其内部状态，通过负责人可以间接访问其内部状态。
 //         4】、有时一些发起人对象的内部信息必须保存在发起人对象以外的地方，但是必须要由发起人对象自己读取，这时，使用备忘录模式可以把复杂的发起人内部信息对其他的对象屏蔽起来，从而可以恰当地保持封装的边界。
 //   （4）备忘录的封装性
 //        1】、为了确保备忘录的封装性，除了原发器外，其他类是不能也不应该访问备忘录类的，在实际开发中，原发器与备忘录之间的关系是非常特殊的，它们要分享信息而不让其他类知道，实现的方法因编程语言的不同而不同。
 //   （5）多备份实现
 //        1】、在负责人中定义一个集合对象来存储多个状态，而且可以方便地返回到某一历史状态。
 //        2】、在备份对象时可以做一些记号，这些记号称为检查点(Check Point)。在使用HashMap等实现时可以使用Key来设置检查点。
   
    //以备份电话号码为例
    

    //发起人角色Originator
    public class MobileOriginator
    {
        //需要备忘录保存的状态数据
        private List<PersonalTelephone> personalTelephones;
        public List<PersonalTelephone> PersonalTelephones
        {
            get=>personalTelephones;
            set => personalTelephones = value;
        }

        public MobileOriginator(List<PersonalTelephone> telephones)
        {
            if (telephones != null)
                personalTelephones = telephones;
            else throw new ArgumentNullException(nameof(telephones));
        }

        //创建备忘录，即新创建一个备忘录对象来保存当前类的状态
        public MobileMemento CreateMemento()
        {
            //使用new List的目的是重新创建一个PersonalTelephone的列表，不会去引用personalTelephones
            return new MobileMemento(new List<PersonalTelephone>(personalTelephones));
        }

        //从备忘录恢复状态数据
        public void SetMementoFrom(MobileMemento memento)
        {
            if(memento!=null)
                this.personalTelephones = memento.PersonalTelephones;
        }

        public void Show()
        {
            this.personalTelephones.ForEach(it => { Console.WriteLine($"Name={it.Name} Telephone={it.Telephone}"); });
        }

    }

    //备忘录角色Memento
    //备份发起人角色Originator的状态数据
    public class MobileMemento
    {
        public List<PersonalTelephone> PersonalTelephones { get; private set; }
        public MobileMemento(List<PersonalTelephone> telephones) => PersonalTelephones = telephones;
    }

    //看守者角色Caretaker
    //负责保存和管理备忘录对象，如果需要保存多个备忘录对象，可以提供增、删等操作来管理备忘录
    public class MobileCaretaker
    {
        //如果需要保存多个备忘录，则可以是用字典或堆栈的形式来保存，堆栈可以反映保存的先后顺序
        //public Dictionary<string,MobileMemento> MobileMementoList { get; set; }
        public MobileMemento MobileMemento { get; set; }
    }





    //电话号码的信息载体
    public sealed class PersonalTelephone
    {
        public string Name { get; set; }
        public string Telephone { get; set; }
    }
}
