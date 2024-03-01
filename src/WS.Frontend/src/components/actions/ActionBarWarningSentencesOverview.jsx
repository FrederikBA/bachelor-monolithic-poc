import { ReactComponent as CloneIcon } from "../../assets/cloneicon.svg";
import { ReactComponent as SelectAllIcon } from "../../assets/selectallicon.svg";
import { ReactComponent as DeleteIcon } from "../../assets/deleteicon.svg";
import { ReactComponent as NewIcon } from "../../assets/newicon.svg";
import { ReactComponent as EditIcon } from "../../assets/editicon.svg";
import ActionButton from "./ActionButton";
import ActionBarDivision from "./ActionBarDivision"

const ActionBarWarningSentencesOverview = ({ selectAllAction, action, hasCheckedSentences, isEditEnabled, openEditModal, openCopyModal }) => {
    return (
        <div className="action-bar" style={{ display: 'flex', justifyContent: 'flex-end', alignItems: 'center' }}>
            <ActionButton icon={<NewIcon />} text="Ny H-sætning" action={action} />
            <ActionButton icon={<EditIcon />} text="Omdøb" action={openEditModal} disabled={!isEditEnabled} />
            <ActionButton icon={<CloneIcon />} text="Kopier" action={openCopyModal} disabled={!hasCheckedSentences} />
            <ActionButton icon={<DeleteIcon />} text="Slet" action={action} disabled={!hasCheckedSentences} />
            <ActionBarDivision />
            <ActionButton icon={<SelectAllIcon />} text="Vælg alle" action={selectAllAction} />
        </div>
    );
}

export default ActionBarWarningSentencesOverview;

