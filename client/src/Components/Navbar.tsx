import { Link } from "react-router";

const Navbar = () => {
  return (
    <nav className="sticky z-10 bg-green-700 shadow-md top-0 flex justify-between gap-4 p-4">
           <ul className="flex text-md space-x-12 text-white">
             <Link to="/">Patients</Link>
             <Link to="/doctors">Doctors</Link>
             <Link to="clinical-records">Clinical Records</Link>
             <Link to="/appointments">Appointments</Link>
           </ul>
    </nav>
  );
};

export default Navbar;
