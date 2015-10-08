namespace Telerik.ILS.Web.StudentsPortal.Areas.Courses.ViewModels.ExamFileEvaluations
{
    using System.Collections.Generic;

    public class HighQualityCode2014ExamEvaluationViewModel
    {
        public static List<Criteria> GetCriterias()
        {
            return new List<Criteria>
            {
                new Criteria("Refactoring (16)", "", new List<Option>()),
                new Criteria("Основните класове на проекта (Ram, Cpu, Motherboard, etc.) са изнесени в отделна библиотека/проект", 
                    "Computers.Common, Computers.Core или друго добре подбрано име", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Частично (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Изнесени са всички текстове като константи", 
                    "Съобщения за грешка, съобщения за изпълнена операция и т.н.", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Частично (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Максималният заряд за батерията е отделна константа", 
                    "Числото 100 в самия клас", new List<Option>
                    {
                        new Option("Да (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Излишната константа Eight е премахната от кода", 
                    "", new List<Option>
                    {
                        new Option("Да (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Премахнат е Middle man от кода", 
                    "Например Program класа, който извиква друг Main метод", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Divergent change - видео картата е разделена от хард диска", 
                    "Двете вече са в отделни класове", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Divergent change - хард диска е разделен от Raid масива", 
                    "Двете вече са в два отделни класа", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Divergent change - цветната видео карта е разделена от монохромната", 
                    "Двете вече са в два отделни класа", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("PC, Laptop и Server са в три отделни класа", 
                    "Трите вече са разделени", new List<Option>
                    {
                        new Option("Да (1.5)", 1.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("По-добро наименование на класове, променливи, полета, пропъртита, методи и параметри", 
                    "Всяко име дава ясна представа за предназначението", new List<Option>
                    {
                        new Option("Да (2)", 2),
                        new Option("Частично (1)", 1),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Имената на всички namespace-и са преправени", 
                    "Всеки namespace е ясно отделен и името му го описва добре", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Частично (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Имената на проекта и решението са наименовани добре", 
                    "Вече не са Niki и Ivo :(", new List<Option>
                    {
                        new Option("Да (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Няма повтарящ се код", 
                    "Спазен е DRY принципа", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Частично (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Кодът се компилира", 
                    "Компилационните грешки са оправени", new List<Option>
                    {
                        new Option("Да (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Кодът се компилира без предупреждения (warnings)", 
                    "Компилационните предупреждения са премахнати (this code sucks например. Ако кодът все още suck-ва може да не се маха :D)", new List<Option>
                    {
                        new Option("Да (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("InvalidArgumentException класът е премахнат и заменен с по-подходящ", 
                    "ArgumentException например", new List<Option>
                    {
                        new Option("Да (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Подбрани са подходящи exception типове", 
                    "Правилно описват възникналата грешка", new List<Option>
                    {
                        new Option("Да (0.5)", 0.5m),
                        new Option("Частично (0.25)", 0.25m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("SquareNumber32 и SquareNumber64 или са обединени заедно в 1 метод или са разделени в отделни класове", 
                    "1 общ базов метод или класове Cpu32Bit и Cpu64Bit например", new List<Option>
                    {
                        new Option("Да (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Премахнати са всички излишни парчета код", 
                    "Например излишни коментари и \"using C = System.Console;\"", new List<Option>
                    {
                        new Option("Да (0.5)", 0.5m),
                        new Option("Частично (0.25)", 0.25m),
                        new Option("Не (0)", 0),
                    }),
                    
                new Criteria("StyleCop (8)", "", new List<Option>()),
                new Criteria("Колко предупреждения дава StyleCop", 
                    "На всички файлове, освен на Unit Test-овете", new List<Option>
                    {
                        new Option("0 предупреждения (8)", 8),
                        new Option("между 1 и 3 предупреждения, включително (7)", 7),
                        new Option("между 4 и 6 предупреждения, включително (6)", 6),
                        new Option("между 7 и 9 предупреждения, включително (5)", 5),
                        new Option("между 10 и 14 предупреждения, включително (4)", 4),
                        new Option("между 15 и 19 предупреждения, включително (3)", 3),
                        new Option("между 20 и 29 предупреждения, включително (2)", 2),
                        new Option("между 30 и 39 предупреждения, включително (1)", 1),
                        new Option("40 и повече предупреждения (0)", 0),
                    }),
                    
                new Criteria("Design Patterns (22)", "", new List<Option>()),
                new Criteria("Използван патърн Simple Factory", 
                    "Например за производителите или за Abstract Factory-та", new List<Option>
                    {
                        new Option("Да (2)", 2),
                        new Option("Частично (1)", 1),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Използван патърн Strategy", 
                    "Всяко заместване на логика или dependency-тата изнесени през интерфейси", new List<Option>
                    {
                        new Option("Да (3)", 3),
                        new Option("Частично (1.5)", 1.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Използван патърн Template Method", 
                    "Например SquareNumber, ако е в базов клас, може максималния параметър при вдигането на квадрата да се решава от темплейтен метод (в наследниците)", new List<Option>
                    {
                        new Option("Да (4)", 4),
                        new Option("Частично (2)", 2),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Използван патърн Abstract Factory", 
                    "Например за производителите на компютри", new List<Option>
                    {
                        new Option("Да (4)", 4),
                        new Option("Частично (2)", 2),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Използван патърн Composite", 
                    "Например за хард дискове и Raid масиви - един Raid масив като композиция от хард дискове", new List<Option>
                    {
                        new Option("Да (4)", 4),
                        new Option("Частично (2)", 2),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Използван патърн Mediator", 
                    "Например имплементация на дънна платка, до която CPU-то и останалите компоненти има достъп и в нея се слагат останалите компоненти да си комуникират един с друг", new List<Option>
                    {
                        new Option("Да (5)", 5),
                        new Option("Частично (2.5)", 2.5m),
                        new Option("Не (0)", 0),
                    }),
                    
                 new Criteria("Unit Testing (12)", "", new List<Option>()),
                 new Criteria("LaptopBattery.Charge - тест за първоначален заряд на батерията (ако не я зареждаме въобще)", 
                    "Незареждана батерия има 50% заряд", new List<Option>
                    {
                        new Option("Да (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                 new Criteria("LaptopBattery.Charge - тест при нормално зареждане дали батерията си сменя заряда", 
                    "Например от 55%, зареждаме я с 24% - крайно състояние 79%", new List<Option>
                    {
                        new Option("Да (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("LaptopBattery.Charge - тест при отрицателен заряд, но никога под 0", 
                    "Например от 46%, подаваме отрицателен заряд -50% - крайно състояние 0%", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("LaptopBattery.Charge - тест при положителен заряд, но никога над 100", 
                    "Например от 46%, подаваме положителен заряд 67% - крайно състояние 100%", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("LaptopBattery.Charge - тест с нулев заряд не променя състоянието на батерията", 
                    "Например от 46%, подаваме нулев заряд 0% - крайно състояние 46%", new List<Option>
                    {
                        new Option("Да (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("LaptopBattery.Charge - има поне 90% Code Coverage", 
                    "Метода е тестван почти напълно", new List<Option>
                    {
                        new Option("Да (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Cpu.SquareNumber - тест за правилно съобщение с удвоеното число", 
                    "Например при 5 - резултат 25", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Cpu.SquareNumber - тест за правилно съобщение с отрицателно число", 
                    "Например при -5 - съобщение за твърде малко число", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Cpu.SquareNumber - тест за правилно съобщение с твърде голямо число при 32-битов процесор", 
                    "Например при 501 - съобщение за твърде голямо число", new List<Option>
                    {
                        new Option("Да (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Cpu.SquareNumber - тест за правилно съобщение с твърде голямо число при 64-битов процесор", 
                    "Например при 1001 - съобщение за твърде голямо число", new List<Option>
                    {
                        new Option("Да (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Cpu.SquareNumber - тест за правилно съобщение с твърде голямо число при 128-битов процесор", 
                    "Например при 2001 - съобщение за твърде голямо число", new List<Option>
                    {
                        new Option("Да (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Cpu.SquareNumber - има поне 90% Code Coverage", 
                    "Метода е тестван почти напълно", new List<Option>
                    {
                        new Option("Да (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Cpu.rand - тест, проверяващ, че random генераторът не надминава максималната му подадена стойност", 
                    "Например при достатъчно на брой създадени рандом числа, нито едно не минава над максималната позволена стойност", new List<Option>
                    {
                        new Option("Да (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Cpu.rand - тест, проверяващ че random генераторът не връща по-малко от минималната му подадена стойност число", 
                    "Например при достатъчно на брой създадени рандом числа, нито едно не е по-малко от минималната позволена стойност", new List<Option>
                    {
                        new Option("Да (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Cpu.rand - тест, проверяващ че random генераторът спазва коректно двете граници и ги счита за валидни стойности", 
                    "Например при минимална граница 1 и максимална граница 1, генераторът винаги връща числото 1", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Cpu.rand - тест, проверяващ че random генераторът връща различни числа (с някакво допустимо отклонение - например 1%)", 
                    "Например при 1000 генерирани числа, нито едно от тях не се повтара повече от 10 пъти", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Не (0)", 0),
                    }),
                 new Criteria("Използван е mocking поне за един обект", 
                    "С Moq или JustMock", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Не (0)", 0),
                    }),
                    
                 new Criteria("Code Documentation (6)", "", new List<Option>()),
                 new Criteria("Документиран ли е IMotherboard интерфейса", 
                    "Без правописни грешки, с ясен текст и добър английски език", new List<Option>
                    {
                        new Option("Да (1.5)", 1.5m),
                        new Option("Да, но може и по-добре (1)", 1),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Документиран ли е IMotherboard.LoadRamValue() метода", 
                    "Без правописни грешки, с ясен текст и добър английски език", new List<Option>
                    {
                        new Option("Да (1.5)", 1.5m),
                        new Option("Да, но може и по-добре (1)", 1),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Документиран ли е IMotherboard.SaveRamValue(int value) метода", 
                    "Без правописни грешки, с ясен текст и добър английски език", new List<Option>
                    {
                        new Option("Да (1.5)", 1.5m),
                        new Option("Да, но може и по-добре (1)", 1),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Документиран ли е IMotherboard.DrawOnVideoCard(string data) метода", 
                    "Без правописни грешки, с ясен текст и добър английски език", new List<Option>
                    {
                        new Option("Да (1.5)", 1.5m),
                        new Option("Да, но може и по-добре (1)", 1),
                        new Option("Не (0)", 0),
                    }),
                    
                new Criteria("Bottlenecks (6)", "", new List<Option>()),
                new Criteria("При генериране на рандом число - да се извиква random.Next директно с границите", 
                    "Вместо да се налучква число в интервала", new List<Option>
                    {
                        new Option("Оправен и описан (3)", 3),
                        new Option("Описан и неоправен, оправен и неописан или частично описан / оправен (1.5)", 1.5m),
                        new Option("Неописан и неоправен (ненамерен) (0)", 0),
                    }),
                new Criteria("При търсене на квадрат на число - да се умножава числото само по себе си", 
                    "Вместо да събира в цикъл много на брой пъти", new List<Option>
                    {
                        new Option("Оправен и описан (3)", 3),
                        new Option("Описан и неоправен, оправен и неописан или частично описан / оправен (1.5)", 1.5m),
                        new Option("Неописан и неоправен (ненамерен) (0)", 0),
                    }),
                    
                new Criteria("Bug Fixing (10)", "", new List<Option>()),
                new Criteria("Липсващ % при изписването на заряд в батерията", 
                    "Не изписва съобщението вярно", new List<Option>
                    {
                        new Option("Оправен и описан (2)", 2),
                        new Option("Описан и неоправен, оправен и неописан или частично описан / оправен (1)", 1),
                        new Option("Неописан и неоправен (ненамерен) (0)", 0),
                    }),
                new Criteria("LaptopBattery не трябва да се използва от фалшивата System.Collections.Generic.dll библиотека (в namespace System), както е дадено в първоначалния код",
                    "Библиотеката се намира в Properties папката", new List<Option>
                    {
                        new Option("Оправен и описан (3)", 3),
                        new Option("Описан и неоправен, оправен и неописан или частично описан / оправен (1.5)", 1.5m),
                        new Option("Неописан и неоправен (ненамерен) (0)", 0),
                    }),
                new Criteria("Приложението не трябва да хвърля NullReferenceException при стартиране на кода",
                    "Run-time bug, който чупи цялата програма", new List<Option>
                    {
                        new Option("Оправен и описан (2)", 2),
                        new Option("Описан и неоправен, оправен и неописан или частично описан / оправен (1)", 1),
                        new Option("Неописан и неоправен (ненамерен) (0)", 0),
                    }),
                new Criteria("Приложението не трябва да хвърля каквито и да е други exception-и при валидни входни данни",
                    "", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Примерният тест за HP минава успешно и изхода е 1 към 1 със заданието",
                    "Случайните числа (Play метода) не ги отчитаме за грешка", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Примерният тест за Dell минава успешно и изхода е 1 към 1 със заданието",
                    "Случайните числа (Play метода) не ги отчитаме за грешка", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Не (0)", 0),
                    }),
                    
                new Criteria("New Features (10)", "", new List<Option>()),
                new Criteria("Имплементиран ли е 128-битов процесор",
                    "", new List<Option>
                    {
                        new Option("Да (3)", 3),
                        new Option("Частично (1.5)", 1.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("128-битовия процесор изчислява ли числата в определения интервал",
                    "От 0 до 2000", new List<Option>
                    {
                        new Option("Да (2)", 2),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Lenovo създава PC коректно",
                    "Напълно по задание", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Частично (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Lenovo създава Server коректно",
                    "Напълно по задание", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Частично (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Lenovo създава Laptop коректно",
                    "Напълно по задание", new List<Option>
                    {
                        new Option("Да (1)", 1),
                        new Option("Частично (0.5)", 0.5m),
                        new Option("Не (0)", 0),
                    }),
                new Criteria("Примерният тест за Lenovo минава успешно и изхода е 1 към 1 със заданието",
                    "Случайните числа (Play метода) не ги отчитаме за грешка", new List<Option>
                    {
                        new Option("Да (2)", 2),
                        new Option("Не (0)", 0),
                    }),
                    
                new Criteria("SOLID (10)", "", new List<Option>()),
                new Criteria("Single Responsibility принцип",
                    "Всеки клас има само една причина за промяна", new List<Option>
                    {
                        new Option("Добре използван и описан (1)", 1),
                        new Option("Частично използван / частично описан (0.5)", 0.5m),
                        new Option("Неописан и неоправен (липсващ) (0)", 0),
                    }),
                new Criteria("Open / Closed принцип",
                    "Отворен за разширение, затворен за промяна", new List<Option>
                    {
                        new Option("Добре използван и описан (2)", 2),
                        new Option("Частично използван / частично описан (1)", 1),
                        new Option("Неописан и неоправен (липсващ) (0)", 0),
                    }),
                new Criteria("Liskov Substitution принцип",
                    "Наследниците успешно заменят базовите си класове", new List<Option>
                    {
                        new Option("Добре използван и описан (2)", 2),
                        new Option("Частично използван / частично описан (1)", 1),
                        new Option("Неописан и неоправен (липсващ) (0)", 0),
                    }),
                new Criteria("Interface Segregation принцип",
                    "Малки, точни и ясни интерфейси, дефиниращи едно единствено нещо", new List<Option>
                    {
                        new Option("Добре използван и описан (2)", 2),
                        new Option("Частично използван / частично описан (1)", 1),
                        new Option("Неописан и неоправен (липсващ) (0)", 0),
                    }),
                new Criteria("Dependency Inversion принцип",
                    "Всичко от което класовете зависят им се подава от класовете, които ги използват", new List<Option>
                    {
                        new Option("Добре използван и описан (3)", 3),
                        new Option("Частично използван / частично описан (1.5)", 1.5m),
                        new Option("Неописан и неоправен (липсващ) (0)", 0),
                    }),
           };
        }
    }
}