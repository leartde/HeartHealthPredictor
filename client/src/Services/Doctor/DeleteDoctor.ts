import axios from "axios";

const DeleteDoctor = async(id:number)=>{
  const baseUrl = import.meta.env.VITE_API_BASE_URL;
  const url = `${baseUrl}/doctors/${id}`;
  try{
    const response = await axios.delete(url);
    if(response.status === 200)return true;
  }
  catch (error){
    console.error("Error deleting doctor:", error);
    return false;
  }
}

export default DeleteDoctor;
