using System;
using System.Collections.Generic;
using StudentInformationSystem.Entity;
using StudentInformationSystem.BusinessLayer.Repository;
using StudentInformationSystem.BusinessLayer.Services;

namespace StudentInformationSystem.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // **************************** Student Details ***************************
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

                // Create Student Object
                Student student = new Student
                {
                    StudentID = student_id,
                    FirstName = first_name,
                    LastName = last_name,
                    DateOfBirth = date,
                    Email = email,
                    Phone = phone
                };

                // **************************** Course Details ***************************
                Console.WriteLine("Enter Course Details:");
                Console.Write("Course ID: ");
                int course_id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Course Name: ");
                string course_name = Console.ReadLine();
                Console.Write("Course Code: ");
                string course_code = Console.ReadLine();

                // Create Course Object
                Course course = new Course
                {
                    CourseID = course_id,
                    CourseName = course_name,
                    CourseCode = course_code
                };

                // **************************** Enrollment Details ***************************
                Console.WriteLine("Enter Enrollment Details:");
                Console.Write("Enrollment ID: ");
                int enrollment_id = Convert.ToInt32(Console.ReadLine());

                // Create Enrollment Object
                Enrollment enrollment = new Enrollment
                {
                    EnrollmentID = enrollment_id,
                    StudentID = student.StudentID,
                    CourseID = course.CourseID,
                    EnrollmentDate = DateTime.Now,
                    Student = student,
                    Course = course
                };

                // Add Enrollment to Student and Course
                student.Enrollments.Add(enrollment);
                course.Enrollments.Add(enrollment);

                // **************************** Teacher Details ***************************
                Console.WriteLine("Enter Teacher Details:");
                Console.Write("Teacher ID: ");
                int teacher_id = Convert.ToInt32(Console.ReadLine());
                Console.Write("First Name: ");
                string teacher_first_name = Console.ReadLine();
                Console.Write("Last Name: ");
                string teacher_last_name = Console.ReadLine();
                Console.Write("Email: ");
                string teacher_email = Console.ReadLine();

                // Create Teacher Object
                Teacher teacher = new Teacher
                {
                    TeacherID = teacher_id,
                    FirstName = teacher_first_name,
                    LastName = teacher_last_name,
                    Email = teacher_email
                };

                // Assign Course to Teacher
                teacher.AssignedCourses.Add(course);

                // **************************** Payment Details ***************************
                Console.WriteLine("Enter Payment Details:");
                Console.Write("Payment ID: ");
                int payment_id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Amount: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Payment Date: ");
                DateTime payment_date = Convert.ToDateTime(Console.ReadLine());

                // Create Payment Object
                Payment payment = new Payment
                {
                    PaymentID = payment_id,
                    StudentID = student.StudentID,
                    Amount = amount,
                    PaymentDate = payment_date,
                    Student = student
                };

                // Check the output by displaying student enrollments
                Console.WriteLine($"Student {student.FirstName} is enrolled in {course.CourseName}.");
                Console.WriteLine($"Teacher {teacher.FirstName} is assigned to the course {course.CourseName}.");
                Console.WriteLine($"Payment of {payment.Amount} made for student {student.FirstName}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
