import React, { useState } from 'react';
import CreatePatient from "../Services/Patient/CreatePatient.ts";
import { useNavigate } from "react-router";

type FormData = {
  firstName: string;
  lastName: string;
  dateOfBirth: string;
  sex: 0 | 1;
  phoneNumber: string;
  email : string;
}
const AddPatient = () => {
  const [formData, setFormData] = useState<Partial<FormData>>({
    sex: 1
  })
  const navigate = useNavigate();
  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: name == "sex"?Number(value):value
  })
    )};
  const handleSubmit = async(e)=>{
    e.preventDefault();
    const result = await CreatePatient(formData);
    if(result)navigate("/patients")

  }
  return (
    <form onSubmit={handleSubmit} className="flex flex-col bg-green-200/80 rounded-md p-4 text-gray-600 gap-2">
      <legend className="text-xl font-bold text-green-800 mb-4">Add a patient</legend>
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

      <div className="w-72 flex justify-between">
        <label className="text-lg" htmlFor="firstName">Date of birth</label>
        <input
          type="date"
          onChange={handleInputChange}
          className="rounded-md bg-gray-100/80 px-2 w-42"
          name="dateOfBirth"
          id="dateOfBirth"
          value={formData.dateOfBirth || ""}
        />
      </div>
      <div className="w-72 flex justify-between">
        <label className="text-lg" htmlFor="chestPainType"> Sex </label>
        <select className="rounded-md bg-gray-100/80 px-2 w-42" onChange={handleInputChange} id="sex" name="sex"
                value={formData.sex}>
          <option value={0}>Female</option>
          <option value={1}>Male</option>

        </select>
      </div>
      <div className="w-72 flex justify-between">
        <label className="text-lg" htmlFor="firstName">Phone</label>
        <input onChange={handleInputChange} className="rounded-md bg-gray-100/80 px-2 w-42"
               name="phoneNumber"
               id="phoneNumber"
               value={formData.phoneNumber}/>
      </div>
      <div className="w-72 flex justify-between">
        <label className="text-lg" htmlFor="firstName">Email</label>
        <input onChange={handleInputChange} className="rounded-md bg-gray-100/80 px-2 w-42"
               name="email"
               id="email"
               value={formData.email}/>
      </div>
      <div className="w-48 p-2">
        <button type="submit"
                className="w-full rounded-md bg-green-500/80 cursor-pointer hover:bg-green-700/80 text-white font-semibold p-1">Submit
        </button>
      </div>
    </form>
  );
};

export default AddPatient;
