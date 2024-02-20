import { ReactComponent as CloneIcon } from "../../assets/cloneicon.svg";
import { ReactComponent as SelectAllIcon } from "../../assets/selectallicon.svg";
import { ReactComponent as DeleteIcon } from "../../assets/deleteicon.svg";
import { ReactComponent as NewIcon } from "../../assets/newicon.svg";
import ActionButton from "./ActionButton";
import ActionBarDivision from "./ActionBarDivision"

const ActionBarWarningSentences = () => {
    const handleButtonClick = () => {
        console.log("Button clicked");
    };

    return (
        <div className="action-bar" style={{ display: 'flex', justifyContent: 'flex-end', alignItems: 'center' }}>
            <ActionButton icon={<NewIcon />} text="Ny H-sætning" action={handleButtonClick} />
            <ActionButton icon={<CloneIcon />} text="Kopier" action={handleButtonClick} />
            <ActionButton icon={<DeleteIcon />} text="Slet" action={handleButtonClick} />
            <ActionBarDivision />
            <ActionButton icon={<SelectAllIcon />} text="Vælg alle" action={handleButtonClick} />
        </div>
    )
}

export default ActionBarWarningSentences;
