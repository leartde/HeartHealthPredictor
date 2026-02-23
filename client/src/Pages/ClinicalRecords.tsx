import React, { useEffect, useState } from 'react';
import Table from "../Components/Table.tsx";
import type { ClinicalRecord } from "../Types/ClinicalRecord.ts";
import FetchAllClinicalRecords from "../Services/ClinicalRecord/FetchAllClinicalRecords.ts";
import { Link } from "react-router";
import DeleteClinicalRecord from "../Services/ClinicalRecord/DeleteClinicalRecord.ts";
import { riskLabel } from "../Utils/riskLabel.ts";

const ClinicalRecords = () => {
  const [clinicalRecords, setClinicalRecords] = useState<ClinicalRecord[]>([]);
  useEffect(() => {
    const getClinicalRecords = async()=>{
      const data = await FetchAllClinicalRecords();
      setClinicalRecords(data);
    }
    getClinicalRecords().then();
  }, []);

  const handleDelete = (id: number) => async () => {
   const result = await DeleteClinicalRecord(id)
    if(result){
      setClinicalRecords(clinicalRecords.filter(record => record.id !== id));
    }
  }
  if(!clinicalRecords){
    return <p className="text-green-800 text-lg">No clinical records found</p>
  }
  return (
    <>
      <h2 className="text-2xl font-bold text-green-800 mb-4">Clinical Records</h2>
      <div className="overflow-x-auto rounded-lg text-green-800 mb-4">
     <Table
      headers={['Id','Patient Name', 'Recorded By Doctor', 'Recorded Date', 'Patient Sex', 'Probability', 'Label', '','']}
      rows={clinicalRecords.map((record) => ([
        record.id,
        `${record.patient.firstName} ${record.patient.lastName}`,
        `${record.recordedByDoctor.firstName} ${record.recordedByDoctor.lastName}`,
        new Date(record.recordedDate).toLocaleDateString(),
        record.patient.sex,
        (Math.round(record.probability * 100 * 100) / 100)+ '%',
        riskLabel(record.probability),
        <Link to={`${record.id}`} className="text-gray-900"> Click here to view full details </Link>,
        <button onClick={handleDelete(record.id)} className="bg-red-600 cursor-pointer hover:bg-red-700 text-white font-bold py-1 px-2 rounded ml-2"> Delete </button>
      ]))}
     />
      </div>

      <div className="p-2 mt-2">
           <Link to="add" className="bg-green-600 hover:bg-green-700 text-white font-bold py-2 px-4 rounded">
             Add new clinical record
           </Link>
      </div>
      </>
  );
};

export default ClinicalRecords;
