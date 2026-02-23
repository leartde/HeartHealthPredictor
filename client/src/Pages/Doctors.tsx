import React, { useEffect, useState } from 'react';
import type { Doctor } from "../Types/Doctor.ts";
import FetchAllDoctors from "../Services/Doctor/FetchAllDoctors.ts";
import Table from "../Components/Table.tsx";
import { Link } from "react-router";
import DeleteDoctor from "../Services/Doctor/DeleteDoctor.ts";

const Doctors = () => {
  const [doctors, setDoctors] = useState<Doctor[]>([]);
  useEffect(() => {
    const getDoctors = async () => {
      const res = await FetchAllDoctors();
      setDoctors(res);
    }
    getDoctors().then()
  },[]);
  const handleDelete = (id: number) => async () => {
    const result = await DeleteDoctor(id);
    if (result) {
      setDoctors(doctors.filter(doctor => doctor.id !== id));
    }
  }
  if(!doctors){
    return <p className="text-green-800 text-lg">No doctors found</p>
  }
  return (
    <>
      <h2 className="text-2xl font-bold text-green-800 mb-4">Doctor Records</h2>

      <div className="overflow-x-auto rounded-lg shadow-md">
        <Table headers={["Id", "First Name", "Last Name", ""]}
               rows={doctors.map((doctor) => ([
                 doctor.id,
                 doctor.firstName,
                 doctor.lastName,
                 <button onClick={handleDelete(doctor.id)}
                         className="bg-red-600 cursor-pointer hover:bg-red-700 text-white font-bold py-1 px-2 rounded ml-2"> Delete </button>

               ]))}
        />

      </div>
      <div className="p-2 mt-2">
        <Link to="add" className="bg-green-600 hover:bg-green-700 text-white font-bold py-2 px-4 rounded">
        Add new doctor
        </Link>
      </div>
    </>
  );
};

export default Doctors;
