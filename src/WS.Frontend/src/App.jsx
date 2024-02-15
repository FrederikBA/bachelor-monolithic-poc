import { BrowserRouter, Routes, Route } from "react-router-dom";
import Header from './components/Header';
import WarningSentenceOverview from "./views/WarningSentenceOverview";
import ProductOverview from "./views/ProductOverview";
import Frontpage from "./views/Frontpage";


const App = () => {

  return (
    <BrowserRouter>
      <Header />
      <Routes>
        <Route path="/" element={<Frontpage />}></Route>
        <Route path="/chemicals" element={<ProductOverview />} />
        <Route path="/warningsentences" element={<WarningSentenceOverview />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;