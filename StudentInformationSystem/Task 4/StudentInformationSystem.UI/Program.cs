using System;
using StudentInformationSystem.Entity;
using StudentInformationSystem.BusinessLayer.Repository;
using StudentInformationSystem.BusinessLayer.Services;
using StudentInformationSystem.BusinessLayer.Exceptions;

namespace StudentInformationSystem.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // ****************************Student details***************************
                Console.WriteLine("Enter student Details:");

                Console.Write("Student ID: ");
                int student_id = Convert.ToInt32(Console.ReadLine());
                Console.Write("First Name: ");
                string first_name = Console.ReadLine();
                Console.Write("Last Name: ");
                string last_name = Console.ReadLine();
                Console.Write("Date of Birth: ");
                string date = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Phone Number: ");
                string phone = Console.ReadLine();

                StudentRepository student_repository = new StudentRepository(student_id, first_name, last_name, date, email, phone);
                StudentService student_service = new StudentService(student_repository);

                // Display before updating details
                student_service.DisplayStudentInfo();

                // Updating and displaying data
                student_service.UpdateStudentInfo("thors", "thorfinn", date, "einara@email.com", "98394939");
                student_service.DisplayStudentInfo();
                student_service.GetEnrolledCourses();

                // ****************************Course Details***************************
                Console.WriteLine("Enter Course Details:");
                Console.Write("Course ID: ");
                int course_id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Course Name: ");
                string course_name = Console.ReadLine();
                Console.Write("Course Code: ");
                string course_code = Console.ReadLine();
                Console.Write("Teacher ID: ");
                int teacher_id = Convert.ToInt32(Console.ReadLine());

                CourseRepository course_repository = new CourseRepository(course_id, course_name, course_code, teacher_id);
                CourseService course_service = new CourseService(course_repository);

                course_service.DisplayCourseInfo();
                course_service.UpdateCourseInfo("CS501", "OOPs Concept", 121);
                course_service.DisplayCourseInfo();

                // ****************************Enrollment Details***************************
                Console.WriteLine("Enter Enrollment Details:");
                Console.Write("Enrollment ID: ");
                int enrollment_id = Convert.ToInt32(Console.ReadLine());
                Enrollment enrollment = new Enrollment
                {
                    EnrollmentID = enrollment_id,
                    StudentID = student_id,
                    CourseID = course_id,
                    EnrollmentDate = DateTime.Now
                };

                // ****************************Teacher Details***************************
                Console.WriteLine("Enter Teacher Details:");
                Console.Write("Teacher ID: ");
                int teacherID = Convert.ToInt32(Console.ReadLine());
                Console.Write("First Name: ");
                string teacherFirstName = Console.ReadLine();
                Console.Write("Last Name: ");
                string teacherLastName = Console.ReadLine();
                Console.Write("Email: ");
                string teacherEmail = Console.ReadLine();
                Teacher teacher = new Teacher
                {
                    TeacherID = teacherID,
                    FirstName = teacherFirstName,
                    LastName = teacherLastName,
                    Email = teacherEmail
                };

                // ****************************Payment Details***************************
                Console.WriteLine("Enter Payment Details:");
                Console.Write("Payment ID: ");
                int payment_id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Amount: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Payment Date: ");
                DateTime payment_date = Convert.ToDateTime(Console.ReadLine());
                Payment payment = new Payment
                {
                    PaymentID = payment_id,
                    StudentID = student_id,
                    Amount = amount,
                    PaymentDate = payment_date
                };

                // Here you can check for any conditions that throw custom exceptions
                // Example: Check for duplicate enrollment
                if (true)
                {
                    throw new DuplicateEnrollmentException("Student is already enrolled in this course.");
                }

                // Similarly handle other conditions to throw respective exceptions

                Console.ReadKey();
            }
            catch (DuplicateEnrollmentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            catch (CourseNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (StudentNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (TeacherNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (PaymentValidationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidStudentDataException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidCourseDataException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidEnrollmentDataException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidTeacherDataException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
