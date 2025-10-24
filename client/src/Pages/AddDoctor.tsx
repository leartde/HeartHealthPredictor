import React, { useState } from 'react';
import { useNavigate } from "react-router";
import CreateDoctor from "../Services/Doctor/CreateDoctor.ts";

type DoctorForm = {
  firstName: string;
  lastName: string;
}
const AddDoctor = () => {
  const [formData, setFormData] = useState<Partial<DoctorForm>>({});
  const navigate = useNavigate();
  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name] :value
    }))};
  const handleSubmit = async(e: React.FormEvent<HTMLFormElement>)=>{
    e.preventDefault();
    const result = await CreateDoctor(formData);
    if(result)navigate("/doctors")
  }
  return (
    <form onSubmit={handleSubmit} className="flex flex-col bg-green-200/80 rounded-md p-4 text-gray-600 gap-2">
      <legend className="text-xl font-bold text-green-800 mb-4">Add a doctor</legend>
      <div className="w-72 flex justify-between">
        <label className="text-lg" htmlFor="firstName">First name</label>
        <input onChange={handleInputChange} className="rounded-md bg-gray-100/80 px-2 w-42"
               name="firstName"
               id="firstName"
               value={formData.firstName}/>
      </div>
      <div className="w-72 flex justify-between">
        <label className="text-lg" htmlFor="firstName">Last name</label>
        <input onChange={handleInputChange} className="rounded-md bg-gray-100/80 px-2 w-42"
               name="lastName"
               id="lastName"
               value={formData.lastName}/>
      </div>
      <div className="w-48 p-2">
        <button type="submit"
                className="w-full rounded-md bg-green-500/80 cursor-pointer hover:bg-green-700/80 text-white font-semibold p-1">Submit
        </button>
      </div>
    </form>
  );
};

export default AddDoctor;
