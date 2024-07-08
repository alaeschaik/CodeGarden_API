using CodeGardenApi.Models;

namespace CodeGardenApi.Data;

public static class DbInitializer
{
    public static void Initialize(CodeGardenContext context)
    {
        context.Database.EnsureCreated();
  
        // Check if data already exists
        if (context.Modules.Any())
        {
            return; // DB has been seeded
        }

        var modules = new[]
        {
            new Module
            {
                Title = "Kotlin",
                Description = "Kotlin Programming Language",
                Introduction = "Kotlin is a statically typed programming language that runs on the Java virtual machine and also can be compiled to JavaScript source code or use the LLVM compiler infrastructure. Its primary development is from a team of JetBrains programmers based in Saint Petersburg, Russia.",
                Sections = new List<Section>
                {
                    new Section
                    {
                        ModuleId = 1,
                        Title = "Introduction to Kotlin",
                        Challenges = new List<Challenge>
                        {
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 1,
                                Content =
                                    @"
                                    <h2>Introduction to Kotlin</h2>
                                    <p>Kotlin is a modern, statically typed programming language that runs on the Java Virtual Machine (JVM) and can also be compiled to JavaScript or native code. Developed by JetBrains, Kotlin is designed to be fully interoperable with Java, making it a popular choice for Android development and other JVM-based projects.</p>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.MultipleChoice,
                                SectionId = 1,
                                Content =
                                    @"
                                    <h2>Introduction to Kotlin Quiz</h2>
                                    <p>Test your knowledge of Kotlin with this multiple-choice quiz. Good luck!</p>",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is Kotlin?",
                                        CorrectAnswer = "Kotlin is a modern, statically typed programming language that runs on the Java Virtual Machine (JVM) and can also be compiled to JavaScript or native code. Developed by JetBrains, Kotlin is designed to be fully interoperable with Java, making it a popular choice for Android development and other JVM-based projects.",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Kotlin is a modern, statically typed programming language that runs on the Java Virtual Machine (JVM) and can also be compiled to JavaScript or native code. Developed by JetBrains, Kotlin is designed to be fully interoperable with Java, making it a popular choice for Android development and other JVM-based projects.",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Kotlin is a dynamically typed programming language that runs on the Java Virtual Machine (JVM) and can also be compiled to JavaScript or native code. Developed by JetBrains, Kotlin is designed to be fully interoperable with Java, making it a popular choice for Android development and other JVM-based projects.",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Kotlin is a statically typed programming language that runs on the Java Virtual Machine (JVM) and can also be compiled to JavaScript or native code. Developed by Google, Kotlin is designed to be fully interoperable with Java, making it a popular choice for Android development and other JVM-based projects.",
                                                IsCorrect = false
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        XpPoints = 25.0m
                    },
                    new Section
                    {
                        ModuleId = 1,
                        Title = "Kotlin Basics",
                        Challenges = new List<Challenge>
                        {
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 2,
                                Content =
                                    @"
                                    <h2>Kotlin Basics</h2>
                                    <p>In this section, you will learn the basic syntax and features of Kotlin. By the end of this section, you will be able to write simple Kotlin programs and understand the foundational elements of the language.</p>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 2,
                                Content = 
                                    @"
                                    <h3>Variables and Data Types</h3>
                                    <p>Kotlin has a strong type system with both mutable and immutable variables:</p>
                                    <pre><code>val name: String = ""Alice"" // immutable
                                    var age: Int = 30 // mutable
                                    </code></pre>"
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 2,
                                Content = 
                                    @"
                                    <p>There are several built-in data types in Kotlin, including:</p>
                                    <ul>
                                        <li>Numbers (Int, Long, Double, etc.)</li>
                                        <li>Booleans (true, false)</li>
                                        <li>Characters (Char)</li>
                                        <li>Strings (String)</li>
                                    </ul>"
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 2,
                                Content = 
                                    @"
                                    <h3>Basic Operators</h3>
                                    <p>Kotlin supports all the standard arithmetic, comparison, and logical operators:</p>
                                    <pre><code>val sum = 1 + 2  // 3
                                    val difference = 5 - 3  // 2
                                    val product = 4 * 6  // 24
                                    val quotient = 10 / 2  // 5
                                    val remainder = 10 % 3  // 1
                                    val greater = 5 > 3  // true
                                    val less = 5 < 3  // false
                                    val equal = 5 == 5  // true
                                    val notEqual = 5 != 3  // true
                                    val and = true && false  // false
                                    val or = true || false  // true
                                    val not = !true  // false
                                    </code></pre>"
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 2,
                                Content = 
                                    @"
                                    <h3>Control Flow Statements</h3>
                                    <p>Kotlin has several control flow statements, including:</p>
                                    <ul>    
                                        <li><code>if</code> statement</li>
                                        <li><code>when</code> expression</li>
                                        <li><code>for</code> loop</li>
                                        <li><code>while</code> loop</li>
                                    </ul>"
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 2,
                                Content = 
                                    @"
                                    <h3>Functions and Lambdas</h3>
                                    <p>Functions in Kotlin are declared using the <code>fun</code> keyword:</p>
                                    <pre><code>fun greet(name: String) {
                                        println(""Hello, $name!"")  
                                    }   
                                    greet(""Alice"")  // Hello, Alice!
                                    </code></pre>
                                                        <p>Lambdas are anonymous functions that can be passed as arguments or stored in variables:</p>
                                    <pre><code>val sum = { a: Int, b: Int -> a + b }
                                    println(sum(1, 2))  // 3
                                    </code></pre>"
                            },
                            new Challenge
                            {
                              ChallengeType  = ChallengeType.Question,
                              SectionId = 2,
                              Content = "What is the keyword used to declare a function in Kotlin?",
                              Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the keyword used to declare a function in Kotlin?",
                                        CorrectAnswer = "fun",
                                        Type = QuestionType.Question
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between val and var in Kotlin?",
                                        CorrectAnswer = "val is immutable, var is mutable",
                                        Type = QuestionType.Question
                                    },
                                    new Question
                                    {
                                        Content = "How do you declare a lambda in Kotlin?",
                                        CorrectAnswer = "{ ... }",
                                        Type = QuestionType.Question
                                    }
                                }
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.MultipleChoice,
                                SectionId = 2,
                                Content =
                                    @"
                                    <h2>Kotlin Basics Multiple Choice Test</h2>
                                    <p>Test your knowledge of the basic syntax and features of Kotlin with this multiple-choice quiz. Good luck!</p>",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the keyword used to declare a function in Kotlin?",
                                        CorrectAnswer = "fun",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "fun",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "function",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "funct",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between val and var in Kotlin?",
                                        CorrectAnswer = "val is immutable, var is mutable",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "val is mutable, var is immutable",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "val is immutable, var is mutable",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "val and var are the same",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "How do you declare a lambda in Kotlin?",
                                        CorrectAnswer = "{ ... }",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "lambda { ... }",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "fun { ... }",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "{ ... }",
                                                IsCorrect = true
                                            }
                                        } 
                                    },
                                }
                            }
                        },
                        XpPoints = 25.0m
                    },
                    new Section
                    {
                       ModuleId = 1,
                       Title = "Object-Oriented Programming in Kotlin",
                       Challenges = new List<Challenge>
                       { 
                           new Challenge
                           {
                               ChallengeType = ChallengeType.LearningContent,
                               SectionId = 3,
                               Content =
                                   @"
                                   <h2>Object-Oriented Programming in Kotlin</h2>
                                   <p>This section covers the principles of object-oriented programming (OOP) in Kotlin, including classes, objects, inheritance, and polymorphism.</p>",
                           }, 
                           new Challenge 
                           {
                              ChallengeType = ChallengeType.LearningContent,
                              SectionId = 3,
                              Content =
                                @"
                                <h3>Classes and Objects</h3>
                                <p>In Kotlin, classes are defined using the <code>class</code> keyword:</p>
                                <pre><code>class Person {
                                     var name: String = """" 
                                     var age: Int = 0
                                }
                                val person = Person()
                                person.name = ""Alice""
                                person.age = 30
                                </code></pre>
                                <p>Objects are instances of classes:</p>
                                <pre><code>val person = Person()
                                person.name = ""Alice""
                                person.age = 30
                                </code></pre>", 
                           }, 
                           new Challenge
                           {
                              ChallengeType = ChallengeType.LearningContent,
                              SectionId = 3,
                              Content =
                                @"
                                <h3>Constructors and Properties</h3>
                                <p>Classes can have primary and secondary constructors:</p>
                                <pre><code>class Person(val name: String, val age: Int) {
                                     // properties
                                }
                                val person = Person(""Alice"", 30)
                                </code></pre>", 
                           }, 
                           new Challenge 
                           {
                              ChallengeType = ChallengeType.LearningContent,
                              SectionId = 3,
                              Content =
                                @"
                                <h3>Inheritance and Interfaces</h3>
                                <p>Kotlin supports single class inheritance
                                and multiple interface inheritance:</p>
                                <pre><code>open class Animal {
                                     open fun speak() {
                                          println(""Animal speaks"")
                                     }
                                }   
                                class Dog : Animal() {
                                     override fun speak() {
                                          println(""Dog barks"")
                                     }
                                }
                                val dog = Dog()
                                dog.speak()  // Dog barks
                                </code></pre>", 
                           },
                           new Challenge 
                           {
                              ChallengeType = ChallengeType.LearningContent,
                              SectionId = 3,
                              Content =
                                @"
                                <h3>Polymorphism and Overriding</h3>
                                <p>Polymorphism allows objects of different classes to be treated as objects of a common superclass:</p>"
                           }, 
                           new Challenge 
                           {
                              ChallengeType = ChallengeType.Question,
                              SectionId = 3,
                              Content = "What is the purpose of classes in Kotlin?",
                              Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the purpose of classes in Kotlin?",
                                        CorrectAnswer = "To define objects with properties and methods",
                                        Type = QuestionType.Question
                                    },
                                    new Question
                                    {
                                        Content = "How are constructors used in Kotlin?",
                                        CorrectAnswer = "To initialize object properties",
                                        Type = QuestionType.Question
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between inheritance and interfaces in Kotlin?",
                                        CorrectAnswer = "Inheritance allows a class to inherit properties and methods from another class, while interfaces define a contract for classes to implement",
                                        Type = QuestionType.Question
                                    }
                                }
                           }, 
                           new Challenge 
                           {
                              ChallengeType = ChallengeType.MultipleChoice,
                              SectionId = 3,
                              Content =
                                @"
                                <h2>Object-Oriented Programming in Kotlin Multiple Choice Test</h2>
                                <p>Test your knowledge of object-oriented programming in Kotlin with this multiple-choice quiz. Good luck!</p>",
                              Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the purpose of classes in Kotlin?",
                                        CorrectAnswer = "To define objects with properties and methods",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "To define objects with properties and methods",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "To create new data types",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "To handle exceptions",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "How are constructors used in Kotlin?",
                                        CorrectAnswer = "To initialize object properties",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "To initialize object properties",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "To create new objects",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "To define methods",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between inheritance and interfaces in Kotlin?",
                                        CorrectAnswer = "Inheritance allows a class to inherit properties and methods from another class, while interfaces define a contract for classes to implement",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Inheritance allows a class to inherit properties and methods from another class, while interfaces define a contract for classes to implement",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Inheritance allows a class to implement multiple interfaces, while interfaces define a hierarchy of classes",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Inheritance allows a class to override methods from another class, while interfaces define a common set of methods",
                                                IsCorrect = false
                                            },
                                            
                                        }
                                    }
                                }
                           }
                           },
                       XpPoints = 25.0m
                    },
                    new Section
                    {
                        ModuleId = 1,
                        Title = "Advanced Kotlin Features",
                        Challenges = new List<Challenge>
                        {
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 4,
                                Content =
                                    @"
                                    <h2>Advanced Kotlin Features</h2>
                                    <p>This section covers some of the more advanced features of Kotlin, including extension functions, data classes, sealed classes, and coroutines.</p>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 4,
                                Content =
                                    @"
                                    <ul>
                                        <li>Extension functions and properties</li>
                                        <li>Data classes and destructuring</li>
                                        <li>Sealed classes and smart casts</li>
                                        <li>Coroutines and asynchronous programming</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 4,
                                Content =
                                    @"
                                    <h3>Extension Functions and Properties</h3>
                                    <p>Extension functions allow you to add new functionality to existing classes without modifying their source code:</p>
                                    <pre><code>fun String.isPalindrome(): Boolean {
                                        return this == this.reversed()
                                    }
                                    println(""radar"".isPalindrome())  // true
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 4,
                                Content =
                                    @"
                                    <h3>Data Classes and Destructuring</h3>
                                    <p>Data classes are used to represent immutable data:</p>
                                    <pre><code>data class Person(val name: String, val age: Int)
                                    val person = Person(""Alice"", 30)
                                    val (name, age) = person
                                    println(name)  // Alice
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 4,
                                Content =
                                    @"
                                    <h3>Sealed Classes and Smart Casts</h3>
                                    <p>Sealed classes are used to represent restricted class hierarchies:</p>
                                    <pre><code>sealed class Result
                                    data class Success(val message: String) : Result()  
                                    data class Error(val message: String) : Result()
                                    fun process(result: Result) {
                                        when (result) {
                                            is Success -> println(""Success: ${result.message}"")
                                            is Error -> println(""Error: ${result.message}"")
                                        }
                                    }
                                    </code></pre>", 
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 4,
                                Content =
                                    @"
                                    <h3>Coroutines and Asynchronous Programming</h3>
                                    <p>Coroutines are a lightweight alternative to threads for asynchronous programming:</p>
                                    <pre><code>fun main() {
                                        GlobalScope.launch {
                                            delay(1000)
                                            println(""World!"")
                                        }
                                        println(""Hello,"")
                                        Thread.sleep(2000)
                                    }
                                    </code></pre>"
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.Question,
                                SectionId = 4,
                                Content = "Kotilin Advanced Quiz",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the purpose of extension functions in Kotlin?",
                                        CorrectAnswer = "To add new functionality to existing classes without modifying their source code"
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between a data class and a regular class in Kotlin?",
                                        CorrectAnswer = "Data classes are used to represent immutable data, while regular classes are mutable"
                                    },
                                    new Question
                                    {
                                        Content = "How are sealed classes used in Kotlin?",
                                        CorrectAnswer = "To represent restricted class hierarchies"
                                    }
                                }
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.MultipleChoice,
                                SectionId = 4,
                                Content =
                                    @"
                                    <h2>Advanced Kotlin Features Multiple Choice Test</h2>
                                    <p>Test your knowledge of the advanced features of Kotlin with this multiple-choice quiz. Good luck!</p>",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the purpose of extension functions in Kotlin?",
                                        CorrectAnswer = "To add new functionality to existing classes",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "To add new functionality to existing classes",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "To create new classes",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "To handle exceptions",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between a data class and a regular class in Kotlin?",
                                        CorrectAnswer = "Data classes are used to represent immutable data, while regular classes are mutable",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Data classes are used to represent immutable data, while regular classes are mutable",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Data classes are used for asynchronous programming, while regular classes are synchronous",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Data classes are used for inheritance, while regular classes are used for interfaces",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "How are sealed classes used in Kotlin?",
                                        CorrectAnswer = "To represent restricted class hierarchies",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "To represent restricted class hierarchies",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "To create new objects",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "To handle exceptions",
                                                IsCorrect = false
                                            }
                                        }
                                    }
                                }
                            }   
                        },
                        XpPoints = 25.0m
                    }
                },
                Content = "Kotlin is a statically typed programming language that runs on the Java virtual machine and also can be compiled to JavaScript source code or use the LLVM compiler infrastructure. Its primary development is from a team of JetBrains programmers based in Saint Petersburg, Russia.",
                TotalXpPoints = 100.0m
            },
            new Module
            {
                Title = "Python",
                Description = "Python Programming Language",
                Introduction = "Python is an interpreted, high-level, general-purpose programming language. Created by Guido van Rossum and first released in 1991, Python's design philosophy emphasizes code readability with its notable use of significant whitespace.",
                Sections = new List<Section>
                {
                    new Section
                    {
                        ModuleId = 2,
                        Title = "Introduction to Python",
                        Challenges = new List<Challenge>
                        {
                          new Challenge
                          {
                              ChallengeType = ChallengeType.LearningContent,
                              SectionId = 5,
                                Content =
                                    @"
                                    <h2>Introduction to Python</h2>
                                    <p>Python is a high-level, interpreted programming language known for its simplicity and readability. In this section, you will learn the basics of Python, including its history, features, and use cases.</p>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 5,
                                Content =
                                    @"
                                    <ul>
                                        <li>Overview of Python</li>
                                        <li>History and development</li>
                                        <li>Key features of Python</li>
                                        <li>Comparison with other languages</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 5,
                                Content =
                                    @"
                                    <h3>Variables and Data Types</h3>
                                    <p>Python has a dynamic type system with both mutable and immutable variables:</p>
                                    <pre><code>name = 'Alice'  # immutable
                                    age = 30  # mutable
                                    </code></pre>
                                    <p>There are several built-in data types in Python, including:</p>"
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 5,
                                Content =
                                    @"
                                    <ul>
                                        <li>Numbers (int, float, complex)</li>
                                        <li>Booleans (True, False)</li>
                                        <li>Strings ('hello', 'world')</li>
                                        <li>Lists ([1, 2, 3])</li>
                                        <li>Dictionaries ({'key': 'value'})</li>
                                        <li>Tuples ((1, 2, 3))</li>
                                        <li>Sets ({1, 2, 3})</li>
                                    </ul>"
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 5,
                                Content =
                                    @"
                                    <h3>Basic Operators</h3>
                                    <p>Python supports all the standard arithmetic, comparison, and logical operators:</p>
                                    <pre><code>sum = 1 + 2  # 3
                                    difference = 5 - 3  # 2
                                    product = 4 * 6  # 24
                                    quotient = 10 / 2  # 5
                                    remainder = 10 % 3  # 1
                                    greater = 5 > 3  # True
                                    less = 5 < 3  # False
                                    equal = 5 == 5  # True
                                    not_equal = 5 != 3  # True
                                    and_op = True and False  # False
                                    or_op = True or False  # True
                                    not_op = not True  # False
                            </code></pre>"
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 5,
                                Content =
                                    @"
                                    <h3>Control Flow Statements</h3>
                                    <p>Python has several control flow statements, including:</p>
                                    <ul>
                                        <li><code>if</code> statement</li>
                                        <li><code>for</code> loop</li>
                                        <li><code>while</code> loop</li>
                                    </ul>"
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 5,
                                Content =
                                    @"
                                    <h3>Functions and Lambdas</h3>
                                    <p>Functions in Python are defined using the <code>def</code> keyword:</p>
                                    <pre><code>def greet(name):
                                        print('Hello, ' + name + '!')
                                    greet('Alice')  # Hello, Alice!
                                    </code></pre>
                                    <p>Lambdas are anonymous functions that can be passed as arguments or stored in variables:</p>
                                    <pre><code>sum = lambda a, b: a + b
                                    print(sum(1, 2))  # 3
                                    </code></pre>"
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.Question,
                                SectionId = 5,
                                Content = "Python Basics Quiz",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is Python known for?",
                                        CorrectAnswer = "Simplicity and readability"
                                    },
                                    new Question
                                    {
                                        Content = "What are some key features of Python?",
                                        CorrectAnswer = "Interpreted, high-level, general-purpose"
                                    },
                                    new Question
                                    {
                                        Content = "How does Python compare to other languages?",
                                        CorrectAnswer = "Emphasizes code readability with significant whitespace"
                                    }
                                }
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.MultipleChoice,
                                SectionId = 5,
                                Content =
                                    @"
                                    <h2>Introduction to Python Multiple Choice Test</h2>
                                    <p>Test your knowledge of Python with this multiple-choice quiz. Good luck!</p>",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is Python known for?",
                                        CorrectAnswer = "Simplicity and readability",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Simplicity and readability",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Speed and performance",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Complexity and verbosity",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "What are some key features of Python?",
                                        CorrectAnswer = "Interpreted, high-level, general-purpose",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Interpreted, high-level, general-purpose",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Compiled, low-level, specialized",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Interpreted, low-level, general-purpose",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "How does Python compare to other languages?",
                                        CorrectAnswer = "Emphasizes code readability with significant whitespace",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Emphasizes code readability with significant whitespace",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Uses braces for block delimiters",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Requires explicit type declarations",
                                                IsCorrect = false
                                            }
                                        }
                                    }
                                }
                            },
                        },
                        XpPoints = 25.0m
                    },
                    new Section
                    {
                      ModuleId  = 2,
                      Title = "Object-Oriented Programming in Python",
                      Challenges = new List<Challenge>
                      {
                          new Challenge
                          {
                              ChallengeType = ChallengeType.LearningContent,
                              SectionId = 6,
                                Content =
                                    @"
                                    <h2>Object-Oriented Programming in Python</h2>
                                    <p>This section covers the principles of object-oriented programming (OOP) in Python, including classes, objects, inheritance, and polymorphism.</p>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 6,
                                Content =
                                    @"
                                    <ul>
                                        <li>Classes and objects</li>
                                        <li>Constructors and properties</li>
                                        <li>Inheritance and interfaces</li>
                                        <li>Polymorphism and overriding</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 6,
                                Content =
                                    @"
                                    <h3>Classes and Objects</h3>
                                    <p>In Python, classes are defined using the <code>class</code> keyword:</p>
                                    <pre><code>class Person:
                                        def __init__(self, name, age):
                                            self.name = name
                                            self.age = age
                                    person = Person('Alice', 30)
                                    </code></pre>
                                    <p>Objects are instances of classes:</p>
                                    <pre><code>person = Person('Alice', 30)
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 6,
                                Content =
                                    @"
                                    <h3>Constructors and Properties</h3>
                                    <p>Classes can have constructors to initialize object properties:</p>
                                    <pre><code>class Person:
                                        def __init__(self, name, age):
                                            self.name = name
                                            self.age = age
                                    person = Person('Alice', 30)
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 6,
                                Content =
                                    @"
                                    <h3>Inheritance and Interfaces</h3>
                                    <p>Python supports single class inheritance
                                    and multiple interface inheritance:</p>
                                    <pre><code>class Animal:
                                        def speak(self):
                                            print('Animal speaks')
                                    class Dog(Animal):
                                        def speak(self):
                                            print('Dog barks')
                                    dog = Dog()
                                    dog.speak()  # Dog barks
                                    </code></pre>
                                    <h3>Polymorphism and Overriding</h3>
                                    <p>Polymorphism allows objects of different classes to be treated as objects of a common superclass:</p>"
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.Question,
                                SectionId = 6,
                                Content = "Object-Oriented Programming in Python Quiz",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the purpose of classes in Python?",
                                        CorrectAnswer = "To define objects with properties and methods",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "How are constructors used in Python?",
                                        CorrectAnswer = "To initialize object properties",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between inheritance and interfaces in Python?",
                                        CorrectAnswer = "Inheritance allows a class to inherit properties and methods from another class, while interfaces define a contract for classes to implement",
                                        Type = QuestionType.Question,
                                    }
                                }
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.MultipleChoice,
                                SectionId = 6,
                                Content =
                                    @"
                                    <h2>Object-Oriented Programming in Python Multiple Choice Test</h2>
                                    <p>Test your knowledge of object-oriented programming in Python with this multiple-choice quiz. Good luck!</p>",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the purpose of classes in Python?",
                                        CorrectAnswer = "To define objects with properties and methods",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "To define objects with properties and methods",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "To create new data types",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "To handle exceptions",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "How are constructors used in Python?",
                                        CorrectAnswer = "To initialize object properties",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "To initialize object properties",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "To create new objects",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "To define methods",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between inheritance and interfaces in Python?",
                                        CorrectAnswer = "Inheritance allows a class to inherit properties and methods from another class, while interfaces define a contract for classes to implement",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Inheritance allows a class to inherit properties and methods from another class, while interfaces define a contract for classes to implement",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Inheritance allows a class to implement multiple interfaces, while interfaces define a hierarchy of classes",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Inheritance allows a class to override  methods from another class, while interfaces define a common set of methods",
                                                IsCorrect = false
                                            }
                                        }
                                    }
                                }
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.Question,
                                SectionId = 6,
                                Content = "Object-Oriented Programming in Python Quiz",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the purpose of classes in Python?",
                                        CorrectAnswer = "To define objects with properties and methods",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "How are constructors used in Python?",
                                        CorrectAnswer = "To initialize object properties",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between inheritance and interfaces in Python?",
                                        CorrectAnswer = "Inheritance allows a class to inherit properties and methods from another class, while interfaces define a contract for classes to implement",
                                        Type = QuestionType.Question,
                                    }
                                }
                          }
                      },
                      XpPoints = 25.0m
                    },
                   new Section
                   {
                       ModuleId = 2,
                          Title = "Advanced Python Features",
                          Challenges = new List<Challenge>
                          {
                              new Challenge
                              {
                                  ChallengeType = ChallengeType.LearningContent,
                                    SectionId = 7,
                                    Content = "<h2>Advanced Python Features</h2><p>This section covers some of the more advanced features of Python, including decorators, generators, context managers, and asynchronous programming with asyncio.</p>",
                              },
                                new Challenge
                                {
                                    ChallengeType = ChallengeType.LearningContent,
                                    SectionId = 7,
                                    Content = "<ul><li>Decorators and closures</li><li>Generators and iterators</li><li>Context managers and the 'with' statement</li><li>Asynchronous programming with asyncio</li></ul>",
                                },
                                new Challenge
                                {
                                    ChallengeType = ChallengeType.LearningContent,
                                    SectionId = 7,
                                    Content = "<h3>Decorators and Closures</h3><p>Decorators are functions that modify the behavior of other functions:</p><pre><code>def decorator(func):def wrapper():print('Before function call')func()print('After function call')return wrapper@decoratordef greet():print('Hello, world!')greet()</code></pre>",
                                },
                                new Challenge
                                {
                                    ChallengeType = ChallengeType.LearningContent,
                                    SectionId = 7,
                                    Content = "<h3>Generators and Iterators</h3><p>Generators are functions that can yield multiple values:</p><pre><code>def fibonacci():a, b = 0, 1while True:yield aa, b = b, a + bfor n in fibonacci():if n > 1000:breakprint(n)</code></pre>",
                                },
                                new Challenge
                                {
                                    ChallengeType = ChallengeType.LearningContent,
                                    SectionId = 7,
                                    Content = "<h3>Context Managers and the 'with' Statement</h3><p>Context managers are used to manage resources and ensure cleanup:</p><pre><code>with open('file.txt', 'r') as file:for line in file:print(line)</code></pre>",
                                },
                                new Challenge
                                {
                                    ChallengeType = ChallengeType.LearningContent,
                                    SectionId = 7,
                                    Content = "<h3>Asynchronous Programming with asyncio</h3><p>Asyncio is a library for asynchronous programming in Python:</p><pre><code>import asyncioasync def hello():await asyncio.sleep(1)print('Hello, world!')asyncio.run(hello())</code></pre>",
                                },
                                new Challenge
                                {
                                    ChallengeType = ChallengeType.Question,
                                    SectionId = 7,
                                    Content = "Advanced Python Features Quiz",
                                    Questions = new List<Question>
                                    {
                                        new Question
                                        {
                                            Content = "What is the purpose of decorators in Python?",
                                            CorrectAnswer = "To modify the behavior of other functions",
                                            Type = QuestionType.Question,
                                        },
                                        new Question
                                        {
                                            Content = "What is the difference between a generator and a regular function in Python?",
                                            CorrectAnswer = "Generators can yield multiple values",
                                            Type = QuestionType.Question,
                                        },
                                        new Question
                                        {
                                            Content = "How are context managers used in Python?",
                                            CorrectAnswer = "To manage resources and ensure cleanup",
                                            Type = QuestionType.Question,
                                        }
                                    }
                                },
                                new Challenge
                                {
                                    ChallengeType = ChallengeType.MultipleChoice,
                                    SectionId = 7,
                                    Content = "<h2>Advanced Python Features Multiple Choice Test</h2><p>Test your knowledge of the advanced features of Python with this multiple-choice quiz. Good luck!</p>",
                                    Questions = new List<Question>
                                    {
                                        new Question
                                        {
                                            Content = "What is the purpose of decorators in Python?",
                                            CorrectAnswer = "To modify the behavior of other functions",
                                            Type = QuestionType.MultipleChoice,
                                            Choices = new List<Choice>
                                            {
                                                new Choice
                                                {
                                                    Content = "To modify the behavior of other functions",
                                                    IsCorrect = true
                                                },
                                                new Choice
                                                {
                                                    Content = "To create new classes",
                                                    IsCorrect = false
                                                },
                                                new Choice
                                                {
                                                    Content = "To handle exceptions",
                                                    IsCorrect = false
                                                }
                                            }
                                        },
                                        new Question
                                        {
                                            Content = "What is the difference between a generator and a regular function in Python?",
                                            CorrectAnswer = "Generators can yield multiple values",
                                            Type = QuestionType.MultipleChoice,
                                            Choices = new List<Choice>
                                            {
                                                new Choice
                                                {
                                                    Content = "Generators can yield multiple values",
                                                    IsCorrect = true
                                                },
                                                new Choice
                                                {
                                                    Content = "Generators are faster than regular functions",
                                                    IsCorrect = false
                                                },
                                                new Choice
                                                {
                                                    Content = "Generators are used for asynchronous programming",
                                                    IsCorrect = false
                                                }
                                            }
                                        },
                                        new Question
                                        {
                                            Content = "How are context managers used in Python?",
                                            CorrectAnswer = "To manage resources and ensure cleanup",
                                            Type = QuestionType.MultipleChoice,
                                            Choices = new List<Choice>
                                            {
                                                new Choice
                                                {
                                                    Content = "To manage resources and ensure cleanup",
                                                    IsCorrect = true
                                                },
                                                new Choice
                                                {
                                                    Content = "To create new objects",
                                                    IsCorrect = false
                                                },
                                                new Choice
                                                {
                                                    Content = "To handle exceptions",
                                                    IsCorrect = false
                                                }
                                            }
                                        }
                                    }
                              }
                       },
                       XpPoints = 25.0m
                   }
                },
                Content = "Python is a high-level, interpreted programming language known for its simplicity and readability. It is widely used in web development, data analysis, artificial intelligence, and scientific computing.",
                TotalXpPoints = 75.0m
            },
            new Module
            {
                Title = "Java",
                Description = "Java Programming Language",
                Introduction = "Java is a high-level, class-based, object-oriented programming language that is designed to have as few implementation dependencies as possible. It is intended to let application developers write once, run anywhere (WORA), meaning that compiled Java code can run on all platforms that support Java without the need for recompilation.",
                Sections = new List<Section>
                {
                    new Section
                    {
                        ModuleId = 3,
                        Title = "Introduction to Java",
                        Challenges = new List<Challenge>
                        {
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 8,
                                Content =
                                    @"
                                    <h2>Introduction to Java</h2>
                                    <p>Java is a popular programming language known for its portability, performance, and security features. In this section, you will learn the basics of Java, including its history, features, and use cases.</p>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 8,
                                Content =
                                    @"
                                    <ul>
                                        <li>Overview of Java</li>
                                        <li>History and development</li>
                                        <li>Key features of Java</li>
                                        <li>Comparison with other languages</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 8,
                                Content =
                                    @"
                                    <h3>Variables and Data Types</h3>
                                    <p>Java has a strong type system with both primitive and reference types:</p>
                                    <pre><code>int age = 30;  // primitive
                                    String name = ""Alice"";  // reference
                                    </code></pre>
                                    <p>There are several built-in data types in Java, including:</p>"
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 8,
                                Content =
                                    @"
                                    <ul>
                                        <li>Numbers (int, long, double)</li>
                                        <li>Booleans (true, false)</li>
                                        <li>Characters (char)</li>
                                        <li>Strings (String)</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 8,
                                Content =
                                    @"
                                    <h3>Basic Operators</h3>
                                    <p>Java supports all the standard arithmetic, comparison, and logical operators:</p>
                                    <pre><code>int sum = 1 + 2;  // 3
                                    int difference = 5 - 3;  // 2
                                    int product = 4 * 6;  // 24
                                    int quotient = 10 / 2;  // 5
                                    int remainder = 10 % 3;  // 1
                                    boolean greater = 5 > 3;  // true
                                    boolean less = 5 < 3;  // false
                                    boolean equal = 5 == 5;  // true
                                    boolean notEqual = 5 != 3;  // true
                                    boolean and = true && false;  // false
                                    boolean or = true || false;  // true
                                    boolean not = !true;  // false
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 8,
                                Content =
                                    @"
                                    <h3>Control Flow Statements</h3>
                                    <p>Java has several control flow statements, including:</p>
                                    <ul>
                                        <li><code>if</code> statement</li>
                                        <li><code>for</code> loop</li>
                                        <li><code>while</code> loop</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 8,
                                Content =
                                    @"
                                    <h3>Functions and Lambdas</h3>
                                    <p>Functions in Java are defined using the <code>void</code> keyword:</p>
                                    <pre><code>void greet(String name) {
                                        System.out.println(""Hello, "" + name + ""!"");
                                    }
                                    greet(""Alice"");  // Hello, Alice!
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.Question,
                                SectionId = 8,
                                Content = "Java Basics Quiz",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the keyword used to declare a function in Java?",
                                        CorrectAnswer = "void",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between primitive and reference types in Java?",
                                        CorrectAnswer = "Primitive types store values directly, while reference types store references to objects",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "How do you declare a lambda in Java?",
                                        CorrectAnswer = "Using the lambda operator (->)",
                                        Type = QuestionType.Question,
                                    }
                                }
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.MultipleChoice,
                                SectionId = 8,
                                Content =
                                    @"
                                    <h2>Java Basics Multiple Choice Test</h2>
                                    <p>Test your knowledge of the basic syntax and features of Java with this multiple-choice quiz. Good luck!</p>",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the keyword used to declare a function in Java?",
                                        CorrectAnswer = "void",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "void",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "fun",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "function",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between primitive and reference types in Java?",
                                        CorrectAnswer = "Primitive types store values directly, while reference types store references to objects",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Primitive types store values directly, while reference types store references to objects",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Primitive types are immutable, while reference types are mutable",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Primitive types are passed by reference, while reference types are passed by value",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "How do you declare a lambda in Java?",
                                        CorrectAnswer = "Using the lambda operator (->)",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Using the lambda operator (->)",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Using the keyword 'lambda'",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Using the keyword 'fun'",
                                                IsCorrect = false
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        XpPoints = 25.0m
                    },
                    new Section
                    {
                        ModuleId = 3,
                        Title = "Java Basics",
                        Challenges = new List<Challenge>
                        {
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 9,
                                Content =
                                    @"
                                    <h2>Java Basics</h2>
                                    <p>In this section, you will learn the basic syntax and features of Java. By the end of this section, you will be able to write simple Java programs and understand the foundational elements of the language.</p>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 9,
                                Content =
                                    @"
                                    <ul>
                                        <li>Variables and data types</li>
                                        <li>Basic operators</li>
                                        <li>Control flow statements (if, for, while)</li>
                                        <li>Functions and lambdas</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 9,
                                Content =
                                    @"
                                    <h3>Variables and Data Types</h3>
                                    <p>Java has a strong type system with both primitive and reference types:</p>
                                    <pre><code>int age = 30;  // primitive
                                    String name = ""Alice"";  // reference
                                    </code></pre>
                                    <p>There are several built-in data types in Java, including:</p>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 9,
                                Content =
                                    @"
                                    <ul>
                                        <li>Numbers (int, long, double)</li>
                                        <li>Booleans (true, false)</li>
                                        <li>Characters (char)</li>
                                        <li>Strings (String)</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 9,
                                Content =
                                    @"
                                    <h3>Basic Operators</h3>
                                    <p>Java supports all the standard arithmetic, comparison, and logical operators:</p>
                                    <pre><code>int sum = 1 + 2;  // 3
                                    int difference = 5 - 3;  // 2
                                    int product = 4 * 6;  // 24
                                    int quotient = 10 / 2;  // 5
                                    int remainder = 10 % 3;  // 1
                                    boolean greater = 5 > 3;  // true
                                    boolean less = 5 < 3;  // false
                                    boolean equal = 5 == 5;  // true
                                    boolean notEqual = 5 != 3;  // true
                                    boolean and = true && false;  // false
                                    boolean or = true || false;  // true
                                    boolean not = !true;  // false
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 9,
                                Content =
                                    @"
                                    <h3>Control Flow Statements</h3>
                                    <p>Java has several control flow statements, including:</p>
                                    <ul>
                                        <li><code>if</code> statement</li>
                                        <li><code>for</code> loop</li>
                                        <li><code>while</code> loop</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 9,
                                Content =
                                    @"
                                    <h3>Functions and Lambdas</h3>
                                    <p>Functions in Java are defined using the <code>void</code> keyword:</p>
                                    <pre><code>void greet(String name) {
                                        System.out.println(""Hello, "" + name + ""!"");
                                    }
                                    greet(""Alice"");  // Hello, Alice!
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.Question,
                                SectionId = 9,
                                Content = "Java Basics Quiz",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the keyword used to declare a function in Java?",
                                        CorrectAnswer = "void",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between primitive and reference types in Java?",
                                        CorrectAnswer = "Primitive types store values directly, while reference types store references to objects",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "How do you declare a lambda in Java?",
                                        CorrectAnswer = "Using the lambda operator (->)",
                                        Type = QuestionType.Question,
                                    }
                                }
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.MultipleChoice,
                                SectionId = 9,
                                Content =
                                    @"
                                    <h2>Java Basics Multiple Choice Test</h2>
                                    <p>Test your knowledge of the basic syntax and features of Java with this multiple-choice quiz. Good luck!</p>",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the keyword used to declare a function in Java?",
                                        CorrectAnswer = "void",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "void",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "fun",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "function",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between primitive and reference types in Java?",
                                        CorrectAnswer = "Primitive types store values directly, while reference types store references to objects",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Primitive types store values directly, while reference types store references to objects",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Primitive types are immutable, while reference types are mutable",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Primitive types are passed by reference, while reference types are passed by value",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "How do you declare a lambda in Java?",
                                        CorrectAnswer = "Using the lambda operator (->)",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Using the lambda operator (->)",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Using the keyword 'lambda'",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Using the keyword 'fun'",
                                                IsCorrect = false
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        XpPoints = 25.0m
                    },
                    new Section
                    {
                        ModuleId = 3,
                        Title = "Object-Oriented Programming in Java",
                        Challenges = new List<Challenge>
                        {
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 10,
                                Content =
                                    @"
                                    <h2>Object-Oriented Programming in Java</h2>
                                    <p>This section covers the principles of object-oriented programming (OOP) in Java, including classes, objects, inheritance, and polymorphism.</p>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 10,
                                Content =
                                    @"
                                    <ul>
                                        <li>Classes and objects</li>
                                        <li>Constructors and properties</li>
                                        <li>Inheritance and interfaces</li>
                                        <li>Polymorphism and overriding</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 10,
                                Content =
                                    @"
                                    <h3>Classes and Objects</h3>
                                    <p>In Java, classes are defined using the <code>class</code> keyword:</p>
                                    <pre><code>public class Person {
                                        private String name;
                                        private int age;
                                        public Person(String name, int age) {
                                            this.name = name;
                                            this.age = age;
                                        }
                                    }
                                    Person person = new Person(""Alice"", 30);
                                    </code></pre>
                                    <p>Objects are instances of classes:</p>
                                    <pre><code>Person person = new Person(""Alice"", 30);
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 10,
                                Content =
                                    @"
                                    <h3>Constructors and Properties</h3>
                                    <p>Classes can have constructors to initialize object properties:</p>
                                    <pre><code>public class Person {
                                        private String name;
                                        private int age;
                                        public Person(String name, int age) {
                                            this.name = name;
                                            this.age = age;
                                        }
                                    }
                                    Person person = new Person(""Alice"", 30);
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 10,
                                Content =
                                    @"
                                    <h3>Inheritance and Interfaces</h3>
                                    <p>Java supports single class inheritance
                                    and multiple interface inheritance:</p>
                                    <pre><code>public class Animal {
                                        public void speak() {
                                            System.out.println(""Animal speaks"");
                                        }
                                    }
                                    public class Dog extends Animal {
                                        public void speak() {
                                            System.out.println(""Dog barks"");
                                        }
                                    }
                                    Dog dog = new Dog();
                                    dog.speak();  // Dog barks  
                                    </code></pre>
                                    <h3>Polymorphism and Overriding</h3>
                                    <p>Polymorphism allows objects of different classes to be treated as objects of a common superclass:</p>"
                            },  
                            new Challenge
                            {
                                ChallengeType = ChallengeType.Question,
                                SectionId = 10,
                                Content = "Object-Oriented Programming in Java Quiz",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the purpose of constructors in Java?",
                                        CorrectAnswer = "To create new objects",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between a class and an object in Java?",
                                        CorrectAnswer = "Classes are instances of objects",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "How does inheritance work in Java?",
                                        CorrectAnswer = "Java supports single class inheritance and multiple interface inheritance",
                                        Type = QuestionType.Question,
                                    }
                                }
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.MultipleChoice,
                                SectionId = 10,
                                Content =
                                    @"
                                    <h2>Object-Oriented Programming in Java Multiple Choice Test</h2>
                                    <p>Test your knowledge of object-oriented programming in Java with this multiple-choice quiz. Good luck!</p>",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the purpose of constructors in Java?",
                                        CorrectAnswer = "To create new objects",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "To create new objects",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "To initialize object properties",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "To handle exceptions",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between a class and an object in Java?",
                                        CorrectAnswer = "Classes are instances of objects",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Classes are instances of objects",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Classes define the structure of objects",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Classes are immutable, objects are mutable",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "How does inheritance work in Java?",
                                        CorrectAnswer = "Java supports single class inheritance and multiple interface inheritance",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Java supports single class inheritance and multiple interface inheritance",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Java supports multiple class inheritance and single interface inheritance",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Java does not support inheritance",
                                                IsCorrect = false
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        XpPoints = 25.0m,
                    },
                    new Section
                    {
                        ModuleId = 3,
                        Title = "Advanced Java Features",
                        Challenges = new List<Challenge>
                        {
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 11,
                                Content =
                                    @"
                                    <h2>Advanced Java Features</h2>
                                    <p>This section covers some of the more advanced features of Java, including annotations, generics, streams, and multithreading.</p>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 11,
                                Content =
                                    @"
                                    <ul>
                                        <li>Annotations and reflection</li>
                                        <li>Generics and type erasure</li>
                                        <li>Streams and lambdas</li>
                                        <li>Multithreading and concurrency</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 11,
                                Content =
                                    @"
                                    <h3>Annotations and Reflection</h3>
                                    <p>Annotations are used to provide metadata about classes, methods, and fields:</p>
                                    <pre><code>@Retention(RetentionPolicy.RUNTIME)
                                    @Target(ElementType.METHOD)
                                    public @interface Log {
                                    }
                                    public class Logger {
                                        @Log
                                        public void log(String message) {
                                            System.out.println(message);
                                        }
                                    }
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 11,
                                Content =
                                    @"
                                    <h3>Generics and Type Erasure</h3>
                                    <p>Generics allow you to create type-safe collections and classes:</p>
                                    <pre><code>public class Box<T> {
                                        private T value;
                                        public T getValue() {
                                            return value;
                                        }
                                        public void setValue(T value) {
                                            this.value = value;
                                        }
                                    }
                                    Box<String> box = new Box<>();
                                    box.setValue(""Hello, world!"");
                                    String value = box.getValue();
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 11,
                                Content =
                                    @"
                                    <h3>Streams and Lambdas</h3>
                                    <p>Streams are used to process collections of data in a functional style:</p>
                                    <pre><code>List<String> names = Arrays.asList(""Alice"", ""Bob"", ""Charlie"");
                                    names.stream()
                                        .filter(name -> name.startsWith(""A""))
                                        .forEach(System.out::println);
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 11,
                                Content =
                                    @"
                                    <h3>Multithreading and Concurrency</h3>
                                    <p>Java supports multithreading and concurrency with the <code>Thread</code> class and the <code>Executor</code> framework:</p>
                                    <pre><code>public class HelloThread
                                        extends Thread {
                                        public void run() {
                                            System.out.println(""Hello, world!"");
                                        }
                                    }
                                    HelloThread thread = new HelloThread();
                                    thread.start();
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.Question,
                                SectionId = 11,
                                Content = "Advanced Java Features Quiz",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the purpose of annotations in Java?",
                                        CorrectAnswer = "To provide metadata about classes, methods, and fields",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between generics and type erasure in Java?",
                                        CorrectAnswer = "Generics allow you to create type-safe collections and classes",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "How are streams used in Java?",
                                        CorrectAnswer = "To process collections of data in a functional style",
                                        Type = QuestionType.Question,
                                    }
                                }
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.MultipleChoice,
                                SectionId = 11,
                                Content =
                                    @"
                                    <h2>Advanced Java Features Multiple Choice Test</h2>
                                    <p>Test your knowledge of the advanced features of Java with this multiple-choice quiz. Good luck!</p>",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the purpose of annotations in Java?",
                                        CorrectAnswer = "To provide metadata about classes, methods, and fields",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "To provide metadata about classes, methods, and fields",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "To create new classes",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "To handle exceptions",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between generics and type erasure in Java?",
                                        CorrectAnswer = "Generics allow you to create type-safe collections and classes",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Generics allow you to create type-safe collections and classes",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Generics are erased at runtime, type erasure is not",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Generics are immutable, type erasure is mutable",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "How are streams used in Java?",
                                        CorrectAnswer = "To process collections of data in a functional style",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "To process collections of data in a functional style",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "To create new objects",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "To handle exceptions",
                                                IsCorrect = false
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        XpPoints = 25.0m
                    }
                },
                Content = "Java is a versatile programming language known for its performance, security, and portability. It is widely used in enterprise applications, web development, mobile apps, and scientific computing.",
                TotalXpPoints = 100.0m
            },
            new Module
            {
                Title = "JavaScript",
                Description = "JavaScript Programming Language",
                Introduction = "JavaScript is a high-level, interpreted programming language that conforms to the ECMAScript specification. It is a versatile language used for both client-side and server-side development, as well as for building mobile and desktop applications.",
                Sections = new List<Section>
                {
                    new Section
                    {
                        ModuleId = 4,
                        Title = "Introduction to JavaScript",
                        Challenges = new List<Challenge>
                        {
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 12,
                                Content =
                                    @"
                                    <h2>Introduction to JavaScript</h2>
                                    <p>JavaScript is a popular programming language known for its versatility and ubiquity. In this section, you will learn the basics of JavaScript, including its history, features, and use cases.</p>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 12,
                                Content =
                                    @"
                                    <ul>
                                        <li>Overview of JavaScript</li>
                                        <li>History and development</li>
                                        <li>Key features of JavaScript</li>
                                        <li>Comparison with other languages</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 12,
                                Content =
                                    @"
                                    <h3>Variables and Data Types</h3>
                                    <p>JavaScript has a dynamic type system with both mutable and immutable variables:</p>
                                    <pre><code>let name = 'Alice';  // mutable
                                    const age = 30;  // immutable
                                    </code></pre>
                                    <p>There are several built-in data types in JavaScript, including:</p>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 12,
                                Content =
                                    @"
                                    <ul>
                                        <li>Numbers (1, 2.5)</li>
                                        <li>Booleans (true, false)</li>
                                        <li>Strings ('hello', 'world')</li>
                                        <li>Arrays ([1, 2, 3])</li>
                                        <li>Objects ({ key: 'value' })</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 12,
                                Content =
                                    @"
                                    <h3>Basic Operators</h3>
                                    <p>JavaScript supports all the standard arithmetic, comparison, and logical operators:</p>
                                    <pre><code>let sum = 1 + 2;  // 3
                                    let difference = 5 - 3;  // 2
                                    let product = 4 * 6;  // 24
                                    let quotient = 10 / 2;  // 5
                                    let remainder = 10 % 3;  // 1
                                    let greater = 5 > 3;  // true
                                    let less = 5 < 3;  // false
                                    let equal = 5 == 5;  // true
                                    let notEqual = 5 != 3;  // true
                                    let and = true && false;  // false
                                    let or = true || false;  // true
                                    let not = !true;  // false
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 12,
                                Content =
                                    @"
                                    <h3>Control Flow Statements</h3>
                                    <p>JavaScript has several control flow statements, including:</p>
                                    <ul>
                                        <li><code>if</code> statement</li>
                                        <li><code>for</code> loop</li>
                                        <li><code>while</code> loop</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 12,
                                Content =
                                    @"
                                    <h3>Functions and Arrow Functions</h3>
                                    <p>Functions in JavaScript are defined using the <code>function</code> keyword:</p>
                                    <pre><code>function greet(name) {
                                        console.log('Hello, ' + name + '!');
                                    }
                                    greet('Alice');  // Hello, Alice!
                                    </code></pre>
                                    <p>Arrow functions provide a more concise syntax for defining functions:</p>
                                    <pre><code>const sum = (a, b) => a + b;
                                    console.log(sum(1, 2));  // 3
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.Question,
                                SectionId = 12,
                                Content = "JavaScript Basics Quiz",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the keyword used to declare a function in JavaScript?",
                                        CorrectAnswer = "function",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between mutable and immutable variables in JavaScript?",
                                        CorrectAnswer = "Mutable variables can be changed, immutable variables cannot",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "How do you declare an arrow function in JavaScript?",
                                        CorrectAnswer = "Using the arrow (=>) syntax",
                                        Type = QuestionType.Question,
                                    }
                                }
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.MultipleChoice,
                                SectionId = 12,
                                Content =
                                    @"
                                    <h2>JavaScript Basics Multiple Choice Test</h2>
                                    <p>Test your knowledge of the basic syntax and features of JavaScript with this multiple-choice quiz. Good luck!</p>",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the keyword used to declare a function in JavaScript?",
                                        CorrectAnswer = "function",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "fun",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "function",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "def",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between mutable and immutable variables in JavaScript?",
                                        CorrectAnswer = "Mutable variables can be changed, immutable variables cannot",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Mutable variables can be changed, immutable variables cannot",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Mutable variables are passed by reference, immutable variables are passed by value",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Mutable variables are stored on the stack, immutable variables are stored on the heap",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "How do you declare an arrow function in JavaScript?",
                                        CorrectAnswer = "Using the arrow (=>) syntax",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Using the arrow (=>) syntax",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Using the keyword 'lambda'",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Using the keyword 'fun'",
                                                IsCorrect = false
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        XpPoints = 25.0m
                    },
                    new Section
                    {
                        ModuleId = 4,
                        Title = "Object-Oriented Programming in JavaScript",
                        Challenges = new List<Challenge>
                        {
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 13,
                                Content =
                                    @"
                                    <h2>Object-Oriented Programming in JavaScript</h2>
                                    <p>This section covers the principles of object-oriented programming (OOP) in JavaScript, including prototypes, classes, inheritance, and polymorphism.</p>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 13,
                                Content =
                                    @"
                                    <ul>
                                        <li>Prototypes and objects</li>
                                        <li>Classes and constructors</li>
                                        <li>Inheritance and mixins</li>
                                        <li>Polymorphism and method overriding</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 13,
                                Content =
                                    @"
                                    <h3>Prototypes and Objects</h3>
                                    <p>JavaScript uses prototypes to define object behavior:</p>
                                    <pre><code>function Person(name, age) {
                                        this.name = name;
                                        this.age = age;
                                    }
                                    let person = new Person('Alice', 30);
                                    </code></pre>
                                    <p>Objects are instances of constructors:</p>
                                    <pre><code>let person = new Person('Alice', 30);
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 13,
                                Content =
                                    @"
                                    <h3>Classes and Constructors</h3>
                                    <p>ES6 introduced class syntax for defining objects:</p>
                                    <pre><code>class Person {
                                        constructor(name, age) {
                                            this.name = name;
                                            this.age = age;
                                        }
                                    }
                                    let person = new Person('Alice', 30);
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 13,
                                Content =
                                    @"
                                    <h3>Inheritance and Mixins</h3>
                                    <p>JavaScript supports prototypal inheritance and mixins:</p>
                                    <pre><code>function Animal() {}
                                    Animal.prototype.speak = function() {
                                        console.log('Animal speaks');
                                    };
                                    function Dog() {}
                                    Dog.prototype = Object.create(Animal.prototype);
                                    Dog.prototype.constructor = Dog;
                                    Dog.prototype.speak = function() {
                                        console.log('Dog barks');
                                    };
                                    let dog = new Dog();
                                    dog.speak();  // Dog barks
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 13,
                                Content =
                                    @"
                                    <h3>Polymorphism and Method Overriding</h3>
                                    <p>Polymorphism allows objects of different classes to be treated as objects of a common superclass:</p>"
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.Question,
                                SectionId = 13,
                                Content = "Object-Oriented Programming in JavaScript Quiz",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the purpose of prototypes in JavaScript?",
                                        CorrectAnswer = "To define object behavior",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between classes and constructors in JavaScript?",
                                        CorrectAnswer = "Classes are instances of constructors",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "How does inheritance work in JavaScript?",
                                        CorrectAnswer = "JavaScript supports prototypal inheritance and mixins",
                                        Type = QuestionType.Question,
                                    }
                                }
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.MultipleChoice,
                                SectionId = 13,
                                Content =
                                    @"
                                    <h2>Object-Oriented Programming in JavaScript Multiple Choice Test</h2>
                                    <p>Test your knowledge of object-oriented programming in JavaScript with this multiple-choice quiz. Good luck!</p>",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the purpose of prototypes in JavaScript?",
                                        CorrectAnswer = "To define object behavior",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "To define object behavior",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "To create new objects",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "To handle exceptions",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between classes and constructors in JavaScript?",
                                        CorrectAnswer = "Classes are instances of constructors",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Classes are instances of constructors",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Classes define the structure of objects",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Classes are immutable, constructors are mutable",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "How does inheritance work in JavaScript?",
                                        CorrectAnswer = "JavaScript supports prototypal inheritance and mixins",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "JavaScript supports prototypal inheritance and mixins",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "JavaScript supports single class inheritance and multiple interface inheritance",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "JavaScript does not support inheritance",
                                                IsCorrect = false
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        XpPoints = 25.0m
                    },
                    new Section
                    {
                        ModuleId = 4,
                        Title = "Advanced JavaScript Features",
                        Challenges = new List<Challenge>
                        {
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 14,
                                Content =
                                    @"
                                    <h2>Advanced JavaScript Features</h2>
                                    <p>This section covers some of the more advanced features of JavaScript, including closures, promises, async/await, and modules.</p>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 14,
                                Content =
                                    @"
                                    <ul>
                                        <li>Closures and lexical scoping</li>
                                        <li>Asynchronous programming with promises</li>
                                        <li>Async/await syntax for asynchronous programming</li>
                                        <li>Modules and module bundlers</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 14,
                                Content =
                                    @"
                                    <h3>Closures and Lexical Scoping</h3>
                                    <p>Closures are functions that capture variables from their lexical environment:</p>
                                    <pre><code>function makeCounter() {
                                        let count = 0;
                                        return function() {
                                            return count++;
                                        };
                                    }
                                    let counter = makeCounter();
                                    console.log(counter());  // 0
                                    console.log(counter());  // 1
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 14,
                                Content =
                                    @"
                                    <h3>Asynchronous Programming with Promises</h3>
                                    <p>Promises are used to handle asynchronous operations in JavaScript:</p>
                                    <pre><code>function fetchData() {
                                        return new Promise((resolve, reject) => {
                                            setTimeout(() => {
                                                resolve('Data fetched');
                                            }, 1000);
                                        });
                                    }
                                    fetchData()
                                        .then(data => console.log(data))
                                        .catch(error => console.error(error));
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 14,
                                Content =
                                    @"
                                    <h3>Async/Await Syntax for Asynchronous Programming</h3>
                                    <p>Async/await provides a more readable syntax for asynchronous programming:</p>
                                    <pre><code>async function fetchData() {
                                        return new Promise((resolve, reject) => {
                                            setTimeout(() => {
                                                resolve('Data fetched');
                                            }, 1000);
                                        });
                                    }
                                    async function main() {
                                        const data = await fetchData();
                                        console.log(data);
                                    }
                                    main();
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 14,
                                Content =
                                    @"
                                    <h3>Modules and Module Bundlers</h3>
                                    <p>ES6 introduced native support for modules in JavaScript:</p>
                                    <pre><code>// math.js
                                    export function sum(a, b) {
                                        return a + b;
                                    }
                                    // app.js
                                    import { sum } from './math.js';
                                    console.log(sum(1, 2));  // 3
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.Question,
                                SectionId = 14,
                                Content = "Advanced JavaScript Features Quiz",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the purpose of closures in JavaScript?",
                                        CorrectAnswer = "To capture variables from their lexical environment",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "How are asynchronous operations handled in JavaScript?",
                                        CorrectAnswer = "Asynchronous operations are handled with promises",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "What is the async/await syntax used for in JavaScript?",
                                        CorrectAnswer = "To provide a more readable syntax for asynchronous programming",
                                        Type = QuestionType.Question,
                                    }
                                }
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.MultipleChoice,
                                SectionId = 14,
                                Content =
                                    @"
                                    <h2>Advanced JavaScript Features Multiple Choice Test</h2>
                                    <p>Test your knowledge of the advanced features of JavaScript with this multiple-choice quiz. Good luck!</p>",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the purpose of closures in JavaScript?",
                                        CorrectAnswer = "To capture variables from their lexical environment",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "To capture variables from their lexical environment",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "To create new objects",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "To handle exceptions",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "How are asynchronous operations handled in JavaScript?",
                                        CorrectAnswer = "Asynchronous operations are handled with promises",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Asynchronous operations are handled with promises",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Asynchronous operations are handled with callbacks",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Asynchronous operations are handled with async/await",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "What is the async/await syntax used for in JavaScript?",
                                        CorrectAnswer = "To provide a more readable syntax for asynchronous programming",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "To create new objects",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "To handle exceptions",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "To provide a more readable syntax for asynchronous programming",
                                                IsCorrect = true
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        XpPoints = 25.0m
                    }
                },
                Content = "JavaScript is a versatile programming language known for its dynamic typing, functional programming features, and asynchronous programming model. It is widely used in web development, server-side applications, and mobile apps.",
                TotalXpPoints = 75.0m
            },
            new Module
            {
                Title = "C#",
                Description = "C# Programming Language",
                Introduction = "C# is a general-purpose, multi-paradigm programming language developed by Microsoft as part of its .NET initiative. C# is designed for Common Language Infrastructure (CLI), which consists of the executable code and runtime environment that allows use of various high-level languages on different computer platforms and architectures.",
                Sections = new List<Section>
                {
                    new Section
                    {
                        ModuleId = 5,
                        Title = "Introduction to C#",
                        Challenges = new List<Challenge>
                        {
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 15,
                                Content =
                                    @"
                                    <h2>Introduction to C#</h2>
                                    <p>C# is a versatile programming language known for its simplicity and power. In this section, you will learn the basics of C#, including its history, features, and use cases.</p>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 15,
                                Content =
                                    @"
                                    <ul>
                                        <li>Overview of C#</li>
                                        <li>History and development</li>
                                        <li>Key features of C#</li>
                                        <li>Comparison with other languages</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 15,
                                Content =
                                    @"
                                    <h3>Variables and Data Types</h3>
                                    <p>C# has a strong type system with both value and reference types:</p>
                                    <pre><code>int age = 30;  // value type
                                    string name = 'Alice';  // reference type
                                    </code></pre>
                                    <p>There are several built-in data types in C#, including:</p>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 15,
                                Content =
                                    @"
                                    <ul>
                                        <li>Numbers (int, long, double)</li>
                                        <li>Booleans (true, false)</li>
                                        <li>Characters (char)</li>
                                        <li>Strings (string)</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 15,
                                Content =
                                    @"
                                    <h3>Basic Operators</h3>
                                    <p>C# supports all the standard arithmetic, comparison, and logical operators:</p>
                                    <pre><code>int sum = 1 + 2;  // 3
                                    int difference = 5 - 3;  // 2
                                    int product = 4 * 6;  // 24
                                    int quotient = 10 / 2;  // 5
                                    int remainder = 10 % 3;  // 1
                                    bool greater = 5 > 3;  // true
                                    bool less = 5 < 3;  // false
                                    bool equal = 5 == 5;  // true
                                    bool notEqual = 5 != 3;  // true
                                    bool and = true && false;  // false
                                    bool or = true || false;  // true
                                    bool not = !true;  // false
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 15,
                                Content =
                                    @"
                                    <h3>Control Flow Statements</h3>
                                    <p>C# has several control flow statements, including:</p>
                                    <ul>
                                        <li><code>if</code> statement</li>
                                        <li><code>for</code> loop</li>
                                        <li><code>while</code> loop</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 15,
                                Content =
                                    @"
                                    <h3>Functions and Lambdas</h3>
                                    <p>Functions in C# are defined using the <code>void</code> keyword:</p>
                                    <pre><code>void Greet(string name) {
                                        Console.WriteLine('Hello, ' + name + '!');
                                    }
                                    Greet('Alice');  // Hello, Alice!
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.Question,
                                SectionId = 15,
                                Content = "C# Basics Quiz",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the keyword used to declare a function in C#?",
                                        CorrectAnswer = "void",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between value and reference types in C#?",
                                        CorrectAnswer = "Value types store their data directly, reference types store a reference to their data",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "How do you declare a lambda function in C#?",
                                        CorrectAnswer = "Using the => syntax",
                                        Type = QuestionType.Question,
                                    }
                                }
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.MultipleChoice,
                                SectionId = 15,
                                Content =
                                    @"
                                    <h2>C# Basics Multiple Choice Test</h2>
                                    <p>Test your knowledge of the basic syntax and features of C# with this multiple-choice quiz. Good luck!</p>",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the keyword used to declare a function in C#?",
                                        CorrectAnswer = "void",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "fun",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "function",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "void",
                                                IsCorrect = true
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between value and reference types in C#?",
                                        CorrectAnswer = "Value types store their data directly, reference types store a reference to their data",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Value types store their data directly, reference types store a reference to their data",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Value types are immutable, reference types are mutable",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Value types are stored on the stack, reference types are stored on the heap",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "How do you declare a lambda function in C#?",
                                        CorrectAnswer = "Using the => syntax",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Using the -> syntax",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Using the => syntax",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Using the =>> syntax",
                                                IsCorrect = false
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        XpPoints = 25.0m
                    },
                    new Section
                    {
                        ModuleId = 5,
                        Title = "Object-Oriented Programming in C#",
                        Challenges = new List<Challenge>
                        {
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 16,
                                Content =
                                    @"
                                    <h2>Object-Oriented Programming in C#</h2>
                                    <p>This section covers the principles of object-oriented programming (OOP) in C#, including classes, objects, inheritance, and polymorphism.</p>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 16,
                                Content =
                                    @"
                                    <ul>
                                        <li>Classes and objects</li>
                                        <li>Constructors and properties</li>
                                        <li>Inheritance and interfaces</li>
                                        <li>Polymorphism and overriding</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 16,
                                Content =
                                    @"
                                    <h3>Classes and Objects</h3>
                                    <p>In C#, classes are defined using the <code>class</code> keyword:</p>
                                    <pre><code>public class Person {
                                        private string name;
                                        private int age;
                                        public Person(string name, int age) {
                                            this.name = name;
                                            this.age = age;
                                        }
                                    }
                                    Person person = new Person('Alice', 30);
                                    </code></pre>
                                    <p>Objects are instances of classes:</p>
                                    <pre><code>Person person = new Person('Alice', 30);
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 16,
                                Content =
                                    @"
                                    <h3>Constructors and Properties</h3>
                                    <p>Classes can have constructors to initialize object properties:</p>
                                    <pre><code>public class Person {
                                        private string name;
                                        private int age;
                                        public Person(string name, int age) {
                                            this.name = name;
                                            this.age = age;
                                        }
                                    }
                                    Person person = new Person('Alice', 30);
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 16,
                                Content =
                                    @"
                                    <h3>Inheritance and Interfaces</h3>
                                    <p>C# supports single class inheritance
                                    and multiple interface inheritance:</p>
                                    <pre><code>public class Animal {
                                        public virtual void Speak() {
                                            Console.WriteLine('Animal speaks');
                                        }
                                    }
                                    public class Dog : Animal {
                                        public override void Speak() {
                                            Console.WriteLine('Dog barks');
                                        }
                                    }
                                    Dog dog = new Dog();
                                    dog.Speak();  // Dog barks
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 16,
                                Content =
                                    @"
                                    <h3>Polymorphism and Overriding</h3>
                                    <p>Polymorphism allows objects of different classes to be treated as objects of a common superclass:</p>"
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.Question,
                                SectionId = 16,
                                Content = "Object-Oriented Programming in C# Quiz",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the purpose of classes and objects in C#?",
                                        CorrectAnswer = "To define object behavior",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "How are constructors used in C#?",
                                        CorrectAnswer = "Constructors are used to initialize object properties",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between inheritance and interfaces in C#?",
                                        CorrectAnswer = "Inheritance allows a class to inherit from another class, interfaces define a contract",
                                        Type = QuestionType.Question,
                                    }
                                }
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.MultipleChoice,
                                SectionId = 16,
                                Content =
                                    @"
                                    <h2>Object-Oriented Programming in C# Multiple Choice Test</h2>
                                    <p>Test your knowledge of object-oriented programming in C# with this multiple-choice quiz. Good luck!</p>",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the purpose of classes and objects in C#?",
                                        CorrectAnswer = "To define object behavior",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "To define object behavior",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "To create new objects",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "To handle exceptions",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "How are constructors used in C#?",
                                        CorrectAnswer = "Constructors are used to initialize object properties",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Constructors are used to initialize object properties",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Constructors are used to create new objects",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Constructors are used to handle exceptions",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "What is the difference between inheritance and interfaces in C#?",
                                        CorrectAnswer = "Inheritance allows a class to inherit from another class, interfaces define a contract",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Inheritance allows a class to inherit from another class, interfaces define a contract",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Inheritance allows a class to implement multiple interfaces",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Inheritance and interfaces are the same in C#",
                                                IsCorrect = false
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        XpPoints = 25.0m
                    },
                    new Section
                    {
                        ModuleId = 5,
                        Title = "Advanced C# Features",
                        Challenges = new List<Challenge>
                        {
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 17,
                                Content =
                                    @"
                                    <h2>Advanced C# Features</h2>
                                    <p>This section covers some of the more advanced features of C#, including LINQ, async/await, delegates, and events.</p>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 17,
                                Content =
                                    @"
                                    <ul>
                                        <li>Language Integrated Query (LINQ)</li>
                                        <li>Asynchronous programming with async/await</li>
                                        <li>Delegates and events</li>
                                        <li>Reflection and attributes</li>
                                    </ul>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 17,
                                Content =
                                    @"
                                    <h3>Language Integrated Query (LINQ)</h3>
                                    <p>LINQ provides a unified way to query data in C#:</p>
                                    <pre><code>var numbers = new int[] { 1, 2, 3, 4, 5 };
                                    var query = from number in numbers
                                                where number % 2 == 0
                                                select number;
                                    foreach (var number in query) {
                                        Console.WriteLine(number);
                                    }
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 17,
                                Content =
                                    @"
                                    <h3>Asynchronous Programming with async/await</h3>
                                    <p>Async/await provides a more readable syntax for asynchronous programming:</p>
                                    <pre><code>async Task<string> FetchDataAsync() {
                                        await Task.Delay(1000);
                                        return 'Data fetched';
                                    }
                                    async Task Main() {
                                        var data = await FetchDataAsync();
                                        Console.WriteLine(data);
                                    }
                                    Main().GetAwaiter().GetResult();
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 17,
                                Content =
                                    @"
                                    <h3>Delegates and Events</h3>
                                    <p>Delegates are used to define and handle events in C#:</p>
                                    <pre><code>public delegate void EventHandler(object sender, EventArgs e);
                                    public class Button {
                                        public event EventHandler Click;
                                        public void OnClick() {
                                            Click?.Invoke(this, EventArgs.Empty);
                                        }
                                    }
                                    Button button = new Button();   
                                    button.Click += (sender, e) => Console.WriteLine('Button clicked');
                                    button.OnClick();  // Button clicked
                                    </code></pre>",
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.LearningContent,
                                SectionId = 17,
                                Content =
                                    @"
                                    <h3>Reflection and Attributes</h3>
                                    <p>Reflection allows you to inspect and manipulate types at runtime:</p>
                                    <pre><code>var type = typeof(Person);
                                    var properties = type.GetProperties();
                                    foreach (var property in properties) {
                                        Console.WriteLine(property.Name);
                                    }
                                    </code></pre>"
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.Question,
                                SectionId = 17,
                                Content = "Advanced C# Features Quiz",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the purpose of LINQ in C#?",
                                        CorrectAnswer = "To query data in a unified way",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "How are asynchronous operations handled in C#?",
                                        CorrectAnswer = "Asynchronous operations are handled with async/await",
                                        Type = QuestionType.Question,
                                    },
                                    new Question
                                    {
                                        Content = "What are delegates and events used for in C#?",
                                        CorrectAnswer = "Delegates and events are used to define and handle events",
                                        Type = QuestionType.Question,
                                    }
                                }
                            },
                            new Challenge
                            {
                                ChallengeType = ChallengeType.MultipleChoice,
                                SectionId = 17,
                                Content =
                                    @"
                                    <h2>Advanced C# Features Multiple Choice Test</h2>
                                    <p>Test your knowledge of the advanced features of C# with this multiple-choice quiz. Good luck!</p>",
                                Questions = new List<Question>
                                {
                                    new Question
                                    {
                                        Content = "What is the purpose of LINQ in C#?",
                                        CorrectAnswer = "To query data in a unified way",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "To query data in a unified way",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "To create new objects",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "To handle exceptions",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "How are asynchronous operations handled in C#?",
                                        CorrectAnswer = "Asynchronous operations are handled with async/await",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Asynchronous operations are handled with async/await",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Asynchronous operations are handled with callbacks",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Asynchronous operations are handled with promises",
                                                IsCorrect = false
                                            }
                                        }
                                    },
                                    new Question
                                    {
                                        Content = "What are delegates and events used for in C#?",
                                        CorrectAnswer = "Delegates and events are used to define and handle events",
                                        Type = QuestionType.MultipleChoice,
                                        Choices = new List<Choice>
                                        {
                                            new Choice
                                            {
                                                Content = "Delegates and events are used to define and handle events",
                                                IsCorrect = true
                                            },
                                            new Choice
                                            {
                                                Content = "Delegates and events are used to create new objects",
                                                IsCorrect = false
                                            },
                                            new Choice
                                            {
                                                Content = "Delegates and events are used to handle exceptions",
                                                IsCorrect = false
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        XpPoints = 25.0m
                    }
                },
                Content = "C# is a versatile programming language known for its simplicity, power, and integration with the .NET framework. It is widely used in web development, desktop applications, and enterprise software.",
                TotalXpPoints = 75.0m
            }
        };
        
        context.Modules.AddRange(modules);
        context.SaveChanges();
    }
}
