import styled, { keyframes, css, createGlobalStyle } from 'styled-components';

export type ContainerProps = {
    vertical?: boolean;
    wide?: boolean;
}

export const Global = createGlobalStyle`
  html {
    overflow-y: overlay;
  }
  
  html * {
    font-size: 1em !important;
    color: #000 !important;
    font-family: Helvetica, serif !important;
  }

  * {
    padding: 2px;
  }
`;

export const Item = styled.div`
  flex-basis: auto;
  margin: 2.5px;
`;

export const Container = styled.div`
  display: flex;
  justify-content: center; 
  
  ${(props: ContainerProps) => {
      if (props.vertical) {
        return css`flex-direction: column;`;
      }
      if (props.wide) {
        return css`
          flex-basis: 70%;
          width: 60%;
          min-width: 60%;
        `;
      }
  }}
`;

export const Box = styled.div`
  background: #fdfdfd;
  border: solid 1px rgba(63, 61, 65, 0.24);
  border-radius: 4px;
  margin-outside: 10px;
  padding: 2.5px;
`;

export const Button = styled.button`
  border: 1px;
  border-radius: 3px;
  padding: 0.15em !important;
  padding-left: 0.5em !important;
  padding-right: 0.5em !important;
  width: fit-content; 
  
  &:hover {
    box-shadow: rgba(194,190,193,0.58) 1px 1px 1px 1px;    
  }
  
  &:disabled {
    background-color: aliceblue;
    padding: 2px;
    color: black !important;
    box-shadow: none;
  }
`;

export const PrimaryButton = styled(Button)`
  background-color: rgba(0,111,218,0.58);
  padding: 2px;
  color: white !important; 
`;

export const DangerButton = styled(Button)`
  background-color: #cb4b49;
  padding: 2px;
  color: white !important;
`;

export const Input = styled.input`
  &:invalid {
    outline: none !important;
    border: 1px solid red;
    border-radius: 2px;
  }
  
  &:focus {
    border: 2px solid red;
    border-radius: 3px;
  }
  
  &.label {
    font-size: 14px !important;   
  }
  
  &.label:empty {
    padding-top: 11px;
    padding-bottom: 11px;   
  }
`;

export const Centered = styled.div`
  margin: 0 auto;
`;

export const Right = styled.div`
    float: right;
`;

export const Left = styled.div`
    float: left;
`;

export const ScrollBar = styled.div`
  overflow: auto;
`;

export const Title = styled.h3`
  font-weight: bold;
  font-size: 1.15em !important;
  font-stretch: extra-condensed;
  padding: 0;
  margin: 0;
`;

export const Divider = styled.span`
  border-top: 1.5px solid #bbb;
  width: 90%;
  margin: auto;
`;

const fadeIn = keyframes`
    0% { opacity: 0; }
    100% { opacity: 1; }
`

export type ToastProps = {
    fadingOut: boolean;
}

export const Toast = styled(Box)`
  text-align: center;
  vertical-align: middle !important;
  
  color: #3d3d3d !important;
  
  padding: 0.5em 1em 0.5em 1em;
  
  min-width: 8em;
  min-height: 2em;
  
  animation-name: ${fadeIn};
  animation-duration: 0.18s;

  ${(props: ToastProps) => {
    if (props.fadingOut) {
      return css`
        opacity: 0;
        transition: opacity 0.18s ease-in-out;
      `;
    }
  }}
`;