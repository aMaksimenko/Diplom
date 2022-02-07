import React from 'react'
// import { Alert } from 'react-bootstrap'
import { types, useInjection } from 'ioc'
import NotificationStore from './Notification.store'
import * as styles from './Notification.styles'
import { observer } from 'mobx-react-lite'

const Notification = observer(() => {
  // const store = useInjection<NotificationStore>(types.NotificationStore)

  return (
    <div style={styles.root}>
      {/*{store.items.map((item, index) => (*/}
      {/*  <Alert*/}
      {/*    key={index}*/}
      {/*    variant="danger"*/}
      {/*    onClose={() => store.remove(index)}*/}
      {/*    dismissible*/}
      {/*  >*/}
      {/*    {item}*/}
      {/*  </Alert>*/}
      {/*))}*/}
    </div>
  )
})

export default Notification
