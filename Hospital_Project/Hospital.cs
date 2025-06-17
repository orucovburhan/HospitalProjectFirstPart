namespace Hospital_Project;

public class Hospital
{
    public static List<Doctor> AllDoctors = new List<Doctor>()
    {
        new Doctor("Jonathan","Behar",12),
        new Doctor("Niket","Patel",18),
        new Doctor("Jonathan","Behar",12),
        new Doctor("Katharine","Hurt",19),
        new Doctor("Eriberto","Farinella",6),
        new Doctor("Marco","Gerlinger",24),
        new Doctor("Anne","Mitchener",34),
        new Doctor("Jonathan","Behar",14),
        new Doctor("Matthew","Foxton",15),
        new Doctor("Andrew","Moore",17),
        new Doctor("Daniel","Fagan",23),
        new Doctor("Rod","Hughes",29),
    };
    public List<Department> Departments = new List<Department>()
    {
        new Department("Pediatrics",new List<Doctor>(){AllDoctors[0],AllDoctors[1],AllDoctors[2],AllDoctors[3]}),
        new Department("Traumatology",new List<Doctor>(){AllDoctors[4],AllDoctors[5],AllDoctors[6]}),
        new Department("Dentistry",new List<Doctor>(){AllDoctors[7],AllDoctors[8],AllDoctors[9],AllDoctors[10],AllDoctors[11]}),
    };


}