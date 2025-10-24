import axios from "axios";

const CreatePatient = async(data)=>{
  const baseUrl = import.meta.env.VITE_API_BASE_URL;
  const url = `${baseUrl}/patients`
  try{
    const response =  await axios.post(url, data);
    if(response.status === 200)return true;
  }
  catch (e){
    console.error("Error adding patient " + e);
    return false;
  }
}

export default CreatePatient;
