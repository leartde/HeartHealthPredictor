import { Outlet } from "react-router";
import Navbar from "./Components/Navbar.tsx";

function App() {
  return (
    <>
      <Navbar />
        <div className="p-6">
          <Outlet  />
        </div>

    </>
  )
}

export default App
