import React, { useContext, useMemo } from 'react'
import { Container, interfaces } from 'inversify'

const InversifyContext = React.createContext<{ container: Container | null }>({ container: null })

type Props = {
  container: Container;
};

export const Provider: React.FC<Props> = (props) => {
  return (
    <InversifyContext.Provider value={{ container: props.container }}>
      {props.children}
    </InversifyContext.Provider>
  )
}

export function useInjection<T>(identifier: interfaces.ServiceIdentifier<T>) {
  const { container } = useContext(InversifyContext)

  if (!container) {
    throw new Error()
  }
  return useMemo(() => container.get<T>(identifier), [container, identifier])
}
